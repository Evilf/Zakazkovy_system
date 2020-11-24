using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Download;
using BarcodeLib;

namespace Zakazkovy_system
{

    public partial class Form_Mainwindow : Form
    {

        public static DataSet Data = new DataSet();
        public static DataTable LoginData = new DataTable("Login");
        public static DataRow CurrentUser;
        private string verzeProgramu = "1.0.0"; 
        static SqlConnection pripojeni;
        static SqlDataAdapter adapter;
        static string FileLocation = @"Zakazkovy_System.xml";
        private Size datagrigsize = new Size(1381, 1060);

        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Google Drive API";

        public Form_Mainwindow()
        {
            InitializeComponent();
            checkControl(this);
            CenterToScreen();
            this.KeyPreview = true;
            Main();
        }

        public void Main()
        {
            Connect();
            //if (pripojeni.State == ConnectionState.Open)
            //{
            //    FillData();
            //    UpdateCombobox_zakazky();
            //}
        }

        private void Form_Mainwindow_Enter(object sender, EventArgs e)
        {
            UpdateCombobox_zakazky();
        }

        public void Connect()
        {
            //try
            //{
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = @"eredmad-PC\SQLExpress";
            //    builder.InitialCatalog = "Servis";
            //    builder.UserID = "sa";
            //    builder.Password = "sssaaa";

            //    pripojeni = new SqlConnection(builder.ConnectionString);
            //    pripojeni.Open();
            //}
            //catch (Exception ex)
            //{
               EventArgs e = new EventArgs();
                //MessageBox.Show(ex.Message);
                toolStripTextBox_Import_XML_Click("", e);
                    
            //}
            LoadLoginInfo();
            Login();
          //  getFilesOnDrive();
        }

        private void LoadLoginInfo()
        {
            DataSet temp = new DataSet();
            temp.ReadXml(@"Login_Values.xml");
            LoginData = temp.Tables[0];
        }

        public void Login ()
        {
            Form_Prihlaseni form_Prihlaseni = new Form_Prihlaseni();
            form_Prihlaseni.Activate();
            form_Prihlaseni.ShowDialog();
            try
            {
                label_Current_user.Text += CurrentUser[0].ToString();
            }
            catch(Exception)
            {

            }
        }

        private void Form_Prihlaseni_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        public static DriveService AuthenticateOauth(string clientSecretJson, string userName)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentNullException("userName");
                if (string.IsNullOrEmpty(clientSecretJson))
                    throw new ArgumentNullException("clientSecretJson");
                if (!System.IO.File.Exists(clientSecretJson))
                    throw new Exception("clientSecretJson file does not exist.");

                string[] scopes = new string[] { DriveService.Scope.Drive };         	                                                
                UserCredential credential;
                using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                                                                             scopes,
                                                                             userName,
                                                                             System.Threading.CancellationToken.None,
                                                                             new FileDataStore(credPath, true)).Result;
                }

                return new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Drive Oauth2 Authentication Sample"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create Oauth2 account DriveService failed" + ex.Message);
                throw new Exception("CreateServiceAccountDriveFailed", ex);
            }
        }

        void getFilesOnDrive()
        {
            var service = AuthenticateOauth(@"client_secret.json", ApplicationName);
            var files = DriveListExample.ListFiles(service,
                 new DriveListExample.FilesListOptionalParms() { Q = "name contains 'Zakazkovy_System.xml'", fields = "*" });
            DownloadFile(service, files.Files[0], @"Zakazkovy_System_google.xml");
        }

        private static void DownloadFile(DriveService service, Google.Apis.Drive.v3.Data.File file, string saveTo)
        {

            var request = service.Files.Get(file.Id);
            var stream = new System.IO.MemoryStream();

            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            SaveStream(stream, saveTo);
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream);


        }

        private static void SaveStream(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }

        private void checkControl(Control control)
        {
            //foreach (Control c in control.Controls)
            //{
            //    var textBox = c as TextBox;
            //    if (textBox != null)
            //        textBox.Font = new Font("Microsoft Sans Serif", 14f);
            //    else
            //        checkControl(c);
            //}
        }

        public void FillData()
        {
            adapter = new SqlDataAdapter("SELECT * FROM Zakazka", pripojeni);
            adapter.Fill(Data, "Zakazka");
            adapter = new SqlDataAdapter("SELECT * FROM Zakaznik", pripojeni);
            adapter.Fill(Data, "Zakaznik");
            adapter = new SqlDataAdapter("SELECT * FROM Zarizeni", pripojeni);
            adapter.Fill(Data, "Zarizeni");

        }

        public void UpdateCombobox_zakazky()
        {
            comboBox_Search_field.Items.Clear();
            foreach (DataRow row in Data.Tables["Zakazka"].Rows)
            {
                comboBox_Search_field.Items.Add(row[0].ToString());

            }
        }

        public void ShowData(string cislo_zakazky)
        {
            DataRow zakazka = null;
            DataRow zakaznik = null;
            DataRow zarizeni = null;

            foreach(DataRow row in Data.Tables[0].Rows)
            {
                if (row[0].ToString().Contains(cislo_zakazky))
                {
                    zakazka = row;
                    foreach (DataRow row1 in Data.Tables[1].Rows)
                    {
                        if (row1[0].ToString() == zakazka[4].ToString())
                        {
                            zakaznik = row1;
                            break;
                        }
                    }

                    foreach (DataRow row2 in Data.Tables[2].Rows)
                    {
                        if (row2[2].ToString() == zakazka[3].ToString())
                        {
                            zarizeni = row2;
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    zakazka = null;
                }

            }

            if(zakazka == null)
            {
                MessageBox.Show("Zakázka číslo: " + comboBox_Search_field.Text + " nebyla nalezena.", "Zakázka nebyla nalezena.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                
            }
            else
            {
                textBox_Cislo_zakazky.Text = zakazka[0].ToString();
                textBox_Cizi_cislo_zakazky.Text = zakazka[1].ToString();
                comboBox_Status.Text = zakazka[2].ToString();
                textBox_Vizualni_stav.Text = zakazka[5].ToString();
                textBox_Popis_zavady.Text = zakazka[6].ToString();
                textBox_Cenovy_limit.Text = zakazka[7].ToString();
                textBox_Reklamace.Text = zakazka[8].ToString();
                textBox_Prijem.Text = zakazka[9].ToString();
                textBox_Diagnostika.Text = zakazka[10].ToString();
                textBox_Vyjadreni_k_oprave.Text = zakazka[11].ToString();
                textBox_Ukonceni.Text = zakazka[12].ToString();
                textBox_Expedice.Text = zakazka[13].ToString();
                textBox_Oprava.Text = zakazka[14].ToString();
                textBox_Diagnostika_datum.Text = zakazka[15].ToString();
                textBox_Dalsi_identifikace.Text = zakazka[16].ToString();
                textBox_SN.Text = zakazka[17].ToString();

                textBox_Spolecnost.Text = zakaznik[1].ToString();
                textBox_Jmeno.Text = zakaznik[2].ToString();
                textBox_Prijmeni.Text = zakaznik[3].ToString();
                textBox_Ulice.Text = zakaznik[4].ToString();
                textBox_Mesto.Text = zakaznik[5].ToString();
                textBox_PSC.Text = zakaznik[6].ToString();
                textBox_Tel.Text = zakaznik[7].ToString();
                textBox_email.Text = zakaznik[8].ToString();
                textBox_ICO.Text = zakaznik[9].ToString();
                textBox_DIC.Text = zakaznik[10].ToString();

                textBox_Vyrobce.Text = zarizeni[0].ToString();
                textBox_Typ_zarizeni.Text = zarizeni[1].ToString();
                textBox_Model.Text = zarizeni[2].ToString();
            }

        }

        public void ClearForm()
        {
            textBox_Cizi_cislo_zakazky.Text = "";
            comboBox_Status.Text = "";
            textBox_Vizualni_stav.Text = "";
            textBox_Popis_zavady.Text = "";
            textBox_Cenovy_limit.Text = "";
            textBox_Reklamace.Text = "";
            textBox_Prijem.Text = "";
            textBox_Diagnostika.Text = "";
            textBox_Vyjadreni_k_oprave.Text = "";
            textBox_Ukonceni.Text = "";
            textBox_Expedice.Text = "";
            textBox_Oprava.Text = "";
            textBox_Diagnostika_datum.Text = "";

            textBox_Spolecnost.Text = "";
            textBox_Jmeno.Text = "";
            textBox_Prijmeni.Text = "";
            textBox_Ulice.Text = "";
            textBox_Mesto.Text = "";
            textBox_PSC.Text = "";
            textBox_Tel.Text = "";
            textBox_email.Text = "";
            textBox_ICO.Text = "";
            textBox_DIC.Text = "";

            textBox_SN.Text = "";
            textBox_Vyrobce.Text = "";
            textBox_Typ_zarizeni.Text = "";
            textBox_Model.Text = "";
            textBox_Dalsi_identifikace.Text = "";

            comboBox_Search_field.Text = "";
        }

        public static void Update_to_database()
        {
            if (pripojeni != null)
            {
                if (pripojeni.State == ConnectionState.Open)
                {
                    SqlCommandBuilder Cmd_builder;
                    try
                    {

                        adapter = new SqlDataAdapter("SELECT * FROM Zakazka", pripojeni);
                        Cmd_builder = new SqlCommandBuilder(adapter);
                        adapter.Update(Data, "Zakazka");
                        adapter = new SqlDataAdapter("SELECT * FROM Zakaznik", pripojeni);
                        Cmd_builder = new SqlCommandBuilder(adapter);
                        adapter.Update(Data, "Zakaznik");
                        adapter = new SqlDataAdapter("SELECT * FROM Zarizeni", pripojeni);
                        Cmd_builder = new SqlCommandBuilder(adapter);
                        adapter.Update(Data, "Zarizeni");
                        MessageBox.Show("Data byla uložena do databáze.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data se nepodařilo uložit do databáze. " + ex.Message);
                    }
                }
                else
                {
                    if (System.IO.File.Exists(FileLocation))
                        Data.WriteXml(FileLocation, XmlWriteMode.WriteSchema);
                    else
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.ShowDialog();
                        FileLocation = saveFileDialog.FileName;
                        Data.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
                    }
                }
            }
        }

        private void BarcodePrint()
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode(textBox_Cislo_zakazky.Text, TYPE.USD8);
            b.Encode(TYPE.USD8, "038000356216", Color.Black, Color.White, 300, 150);
            b.SaveImage("Barcode0001.jpg", SaveTypes.JPG);

        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            ShowData(comboBox_Search_field.Text);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if((string)CurrentUser[2] == "Admin") {
            Form_tvorba_zakazky Okno_Tvorba_Zakazky = new Form_tvorba_zakazky();
            Okno_Tvorba_Zakazky.Activate();
            Okno_Tvorba_Zakazky.Show();
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); 
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if ((string)CurrentUser[2] == "Admin")
            {
                foreach (DataRow row in Data.Tables[0].Rows)
                {
                    if (row[0].ToString() == comboBox_Search_field.Text)
                    {
                        if (MessageBox.Show("Smazat záznam číslo: " + comboBox_Search_field.Text + "?", "Smazat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            row.Delete();
                            Update_to_database();
                            UpdateCombobox_zakazky();
                            ClearForm();
                            break;
                        }
                    }
                }
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void button_Update_Row_Click(object sender, EventArgs e)
        {
            if ((string)CurrentUser[2] == "Admin" || (string)CurrentUser[2] == "User")
            {
                foreach (DataRow row in Data.Tables[0].Rows)
                {
                    if (row[0].ToString() == comboBox_Search_field.Text)
                    {
                        row.BeginEdit();
                        row[1] = textBox_Cizi_cislo_zakazky.Text;
                        row[2] = comboBox_Status.Text;
                        row[5] = textBox_Vizualni_stav.Text;
                        row[6] = textBox_Popis_zavady.Text;
                        row[7] = textBox_Cenovy_limit.Text;
                        row[8] = textBox_Reklamace.Text;
                        row[9] = textBox_Prijem.Text;
                        row[10] = textBox_Diagnostika.Text;
                        row[11] = textBox_Vyjadreni_k_oprave.Text;
                        row[12] = textBox_Ukonceni.Text;
                        row[13] = textBox_Expedice.Text;
                        row[14] = textBox_Oprava.Text;
                        row[15] = textBox_Diagnostika_datum.Text;
                        row[16] = textBox_Dalsi_identifikace.Text;
                        row[17] = textBox_SN.Text;
                        row.EndEdit();
                        button_Update_Row.ForeColor = Color.Green;
                        break;
                    }
                    else
                    {
                        button_Update_Row.ForeColor = Color.Red;
                    }
                }
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void button_zakaznici_Click(object sender, EventArgs e)
        {
            if ((string)CurrentUser[2] == "Admin")
            {
                Form_zakaznik Okno_zakaznici = new Form_zakaznik();
                Okno_zakaznici.Activate();
                Okno_zakaznici.Show();
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void comboBox_Search_field_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ShowData(comboBox_Search_field.Text);
            }
        }

        private void textBox_email_DoubleClick(object sender, EventArgs e)
        { 
                System.Diagnostics.Process.Start("mailto:" + textBox_email.Text);
            
        }

        private void button_zarizeni_Click(object sender, EventArgs e)
        {
            if ((string)CurrentUser[2] == "Admin" || (string)CurrentUser[2] == "User")
            {
                Form_zarizeni Okno_zarizeni = new Form_zarizeni();
                Okno_zarizeni.Activate();
                Okno_zarizeni.Show();
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void Form_Mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Update_to_database();
        }

        private void Form_Mainwindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                button_Update_Row_Click("", e);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                toolStripTextBox_Print_Click("", e);
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.B)
            {
                BarcodePrint();
            }
        }

        private void toolStripTextBox_Export_XML_Click(object sender, EventArgs e)
        {
            if ((string)CurrentUser[2] == "Admin")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.ShowDialog();
                Data.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void toolStripTextBox_Import_XML_Click(object sender, EventArgs e)
        {
                if (Data.Tables.Count == 3)
                {
                    Data.Tables[0].Rows.Clear();
                    Data.Tables[0].AcceptChanges();
                    Data.Tables[1].Rows.Clear();
                    Data.Tables[1].AcceptChanges();
                    Data.Tables[2].Rows.Clear();
                    Data.Tables[2].AcceptChanges();
                }
                if (!System.IO.File.Exists(FileLocation))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.ShowDialog();
                    FileLocation = openFileDialog.FileName;
                    Data.ReadXml(openFileDialog.FileName, XmlReadMode.ReadSchema);
                    UpdateCombobox_zakazky();
                }
                else
                {
                    Data.ReadXml(FileLocation, XmlReadMode.ReadSchema);
                    UpdateCombobox_zakazky();
                }
        }

        private void toolStripTextBox_Print_Click(object sender, EventArgs e)
        {
            if ((string)CurrentUser[2] == "Admin" || (string)CurrentUser[2] == "User")
            {
                Form_Tisk tisk = new Form_Tisk(comboBox_Search_field.Text);
                tisk.Show();
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        int color;
        string colortochange;
        private void timer_Graphics_Tick(object sender, EventArgs e)
        {
            if(button_Update_Row.ForeColor == Color.Red)
            {
                colortochange = "Red";
                color = 254;
            }
            if (button_Update_Row.ForeColor == Color.Green)
            {
                colortochange = "Green";
                color = 254;
            }

            if (colortochange == "Green")
            {
                if (button_Update_Row.ForeColor != Color.FromArgb(0, 0, 0))
                {
                    button_Update_Row.ForeColor = Color.FromArgb(0, color, 0);
                    color--;
                }
            }
            else if (colortochange == "Red")
            {
                if (button_Update_Row.ForeColor != Color.FromArgb(0, 0, 0))
                {
                    button_Update_Row.ForeColor = Color.FromArgb(color, 0, 0);
                    color--;
                }
            }
        }

        string textboxtochange;
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (textboxtochange == "Reklamace")
                textBox_Reklamace.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            else if (textboxtochange == "Prijem")
                textBox_Prijem.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            else if (textboxtochange == "Diagnostika")
                textBox_Diagnostika_datum.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            else if (textboxtochange == "Oprava")
                textBox_Oprava.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            else if (textboxtochange == "Ukonceni")
                textBox_Ukonceni.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            else if (textboxtochange == "Expedice")
                textBox_Expedice.Text = monthCalendar1.SelectionStart.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            monthCalendar1.Visible = false;
        }

        private void textBox_Reklamace_DoubleClick(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(textBox_Reklamace.Location.X, textBox_Reklamace.Location.Y - monthCalendar1.Height);
            monthCalendar1.Visible = true;
            textboxtochange = "Reklamace";
        }

        private void textBox_Prijem_DoubleClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Location = new Point(textBox_Prijem.Location.X, textBox_Prijem.Location.Y - monthCalendar1.Height);
            monthCalendar1.Visible = true;
            textboxtochange = "Prijem";
        }

        private void textBox_Diagnostika_datum_DoubleClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Location = new Point(textBox_Diagnostika_datum.Location.X, textBox_Diagnostika_datum.Location.Y - monthCalendar1.Height);
            monthCalendar1.Visible = true;
            textboxtochange = "Diagnostika";
        }

        private void textBox_Oprava_DoubleClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Location = new Point(textBox_Oprava.Location.X, textBox_Oprava.Location.Y - monthCalendar1.Height);
            monthCalendar1.Visible = true;
            textboxtochange = "Oprava";
        }

        private void textBox_Ukonceni_DoubleClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Location = new Point(textBox_Ukonceni.Location.X, textBox_Ukonceni.Location.Y - monthCalendar1.Height);
            monthCalendar1.Visible = true;
            textboxtochange = "Ukonceni";
        }

        private void textBox_Expedice_DoubleClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.Location = new Point(textBox_Expedice.Location.X, textBox_Expedice.Location.Y - monthCalendar1.Height);
            monthCalendar1.Visible = true;
            textboxtochange = "Expedice";
        }

        private void button_List_zakaznici_Click(object sender, EventArgs e)
        {
            if(dataGridView_List.Visible == false)
            {
                dataGridView_List.DataSource = Data.Tables[1];
                dataGridView_List.Visible = true;
                dataGridView_List.Size = datagrigsize;
            }
            else
            {
                dataGridView_List.Visible = false;
                dataGridView_List.Size = new Size(10, 10);
            }
        }

        private void button_List_zarizeni_Click(object sender, EventArgs e)
        {
            if (dataGridView_List.Visible == false)
            {
                dataGridView_List.DataSource = Data.Tables[2];
                dataGridView_List.Visible = true;
                dataGridView_List.Size = datagrigsize;
            }
            else
            {
                dataGridView_List.Visible = false;
                dataGridView_List.Size = new Size(10, 10);
            }
        }

        private void button_Sprava_Uctu_Click(object sender, EventArgs e)
        {
            if ((string)CurrentUser[2] == "Admin" )
            {
                Form_Sprava_uctu form_Sprava_Uctu = new Form_Sprava_uctu();
                form_Sprava_Uctu.Activate();
                form_Sprava_Uctu.Show();
            }
            else
                MessageBox.Show("Nemáte potřebná oprávnění!", "Bez Oprávnění", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }

    public class DriveListExample
    {
        public class FilesListOptionalParms
        {
            public string Corpus { get; set; }
            public string OrderBy { get; set; }
            public int? PageSize { get; set; }
            public string PageToken { get; set; }
            public string Q { get; set; }
            public string Spaces { get; set; }
            public string fields { get; set; }
            public string quotaUser { get; set; }
            public string userIp { get; set; }
        }

        public static Google.Apis.Drive.v3.Data.FileList ListFiles(DriveService service, FilesListOptionalParms optional = null)
        {
            try
            {
                if (service == null)
                    throw new ArgumentNullException("service");

                var request = service.Files.List();
                request = (FilesResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Files.List failed.", ex);
            }
        }


    }
    public static class SampleHelpers
    {
        public static object ApplyOptionalParms(object request, object optional)
        {
            if (optional == null)
                return request;

            System.Reflection.PropertyInfo[] optionalProperties = (optional.GetType()).GetProperties();

            foreach (System.Reflection.PropertyInfo property in optionalProperties)
            {
                System.Reflection.PropertyInfo piShared = (request.GetType()).GetProperty(property.Name);
                if (property.GetValue(optional, null) != null)
                    piShared.SetValue(request, property.GetValue(optional, null), null);
            }

            return request;
        }
    }
}
