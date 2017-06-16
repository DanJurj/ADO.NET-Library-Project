using Biblioteca.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class MainForm : Form
    {
        private BusinessLayer _legBusinessLayer = new BusinessLayer();
        public MainForm()
        {
            InitializeComponent();
            textBox_limit.Text = "30";
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if(Application.OpenForms.Count<=1)
                Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            labelData.Text = DateTime.Now.ToLongDateString();
            RefreshStatistics();
            dgv_Clients.DataSource = _legBusinessLayer.GetClients();
            tb_Search.Hide();
            HideAB();
            btn_ADD_Loan.Enabled = false;
            dgv_regClients.DataSource = _legBusinessLayer.ViewAllRegisteredClients();
            LockClientTextBoxes();
            btn_saveClient.Hide();
            btn_CancelClient.Hide();
            btn_add.Hide();
            dgv_BookEvidence.DataSource = _legBusinessLayer.ViewAllBooks();
            btn_saveBook.Hide();
            btn_cancelBook.Hide();
            btn_add2.Hide();
            LockBookTextBoxes();
        }
        //Statistics Tab
        private void RefreshStatistics()
        {
            labelCAbonati.Text = _legBusinessLayer.CountAbonati().ToString();
            labelCCarti.Text = _legBusinessLayer.CountCarti().ToString();
            labelCExemplare.Text = _legBusinessLayer.CountExemplare().ToString();
            labelCImprumuturi.Text = _legBusinessLayer.CountImprumuturi().ToString();
            labelCAB.Text = _legBusinessLayer.CountAB().ToString();
            labelCAutori.Text = _legBusinessLayer.CountAutori().ToString();
            labelCEdituri.Text = _legBusinessLayer.CountEdituri().ToString();
            label_excedeed.Hide();
        }
        private void HideAB()
        {
            dgv_AB.Hide();
            labelAB.Hide();
            cBoxAB.Hide();
            tBoxAB.Hide();
        }
        private void ShowAB()
        {
            dgv_AB.Show();
            labelAB.Show();
            cBoxAB.Show();
        }
        private void tabStat_Click(object sender, EventArgs e)
        {

        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshStatistics();
        }
        private void btn_detailsAbonati_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = _legBusinessLayer.GetAbonati();
        }
        private void btn_detailsCarti_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = _legBusinessLayer.GetCarti();
        }
        private void btn_detailsExemplare_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = _legBusinessLayer.GetExemplare();
        }
        private void btn_detailsImprumuturi_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = _legBusinessLayer.GetImprumuturi();
        }
        private void btn_detailsAB_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = _legBusinessLayer.GetAB();
        }
        private void btn_detailsAutori_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = _legBusinessLayer.GetAutori();
        }
        private void btn_detailsEdituri_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = _legBusinessLayer.GetEdituri();
        }
        private void btn_clr_Click(object sender, EventArgs e)
        {
            ViewDetails.DataSource = " ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label_excedeed.Show();
            int nr = int.Parse(textBox_limit.Text);
            label_excedeed.Text = _legBusinessLayer.CountDelays(nr).ToString();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            int nr = int.Parse(textBox_limit.Text);
            ViewDetails.DataSource = _legBusinessLayer.GetDelays(nr);
        }



        //Clients-> Loans
        public void FillLoans(int id_user)
        {
            dgv_Loans.DataSource = _legBusinessLayer.GetLoansFor(id_user);
        }
        private bool CheckIfSelected(DataGridViewCellMouseEventArgs e, DataGridView table)
        {
            if (e.RowIndex != -1 && e.RowIndex != table.RowCount - 1)
                return true;
            return false;
        }
        private void dgv_Clients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.RowIndex != dgv_Clients.RowCount - 1)
            {
                int id_user = int.Parse(dgv_Clients.Rows[e.RowIndex].Cells[0].Value.ToString());
                string pren = dgv_Clients.Rows[e.RowIndex].Cells[2].Value.ToString();
                string num = dgv_Clients.Rows[e.RowIndex].Cells[1].Value.ToString();
                labelClientName.Text = pren;
                FillLoans(id_user);
            }
        }

        //Search Clients
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Search.Show();
        }
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToString())
            {
                case "Nume":
                    dgv_Clients.DataSource = _legBusinessLayer.SearchClientsByName(tb_Search.Text.ToString());
                    break;
                case "Prenume":
                    dgv_Clients.DataSource = _legBusinessLayer.SearchClientsByPrenume(tb_Search.Text.ToString());
                    break;
                case "CNP":
                    dgv_Clients.DataSource = _legBusinessLayer.SearchClientsByCNP(tb_Search.Text.ToString());
                    break;
                default:
                    break;
            }
            if (tb_Search.Text.ToString() == "")
                dgv_Clients.DataSource = _legBusinessLayer.GetClients();
        }

        //Delete Loan
        private void btn_dLoan_Click(object sender, EventArgs e)
        {
            if (dgv_Loans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Va rugam selectati imprumutul pe care doriti sa-l stergeti mai intai!");
                return;
            }
            int id_abonat = int.Parse(dgv_Clients.SelectedRows[0].Cells[0].Value.ToString());
            string titlu = dgv_Loans.SelectedRows[0].Cells[0].Value.ToString();
            _legBusinessLayer.DeleteLoan(id_abonat, titlu);
            dgv_Loans.DataSource = _legBusinessLayer.GetLoansFor(id_abonat);
        }

        //ADD Loan
        private void tb_search_bookID_TextChanged(object sender, EventArgs e)
        {
            btn_ADD_Loan.Enabled = true;
        }
        private bool CheckIfBookAvailable(int id)
        {
            bool val = _legBusinessLayer.CheckIfBookAvailable(id);
            return val;
        }
        private bool CheckIfAlreadyLoaned(int id_abonat, int id_carte)
        {
            bool val = _legBusinessLayer.CheckIfAlreadyLoaned(id_abonat, id_carte);
            return val;
        }
        private void btn_ADD_Loan_Click(object sender, EventArgs e)
        {
            if (tb_search_bookID.Text.ToString() == "")
            {
                MessageBox.Show("Va rog introduceti ID-ul carti!");
                return;
            }
            int id_titlu = int.Parse(tb_search_bookID.Text.ToString());
            int id_abonat = int.Parse(dgv_Clients.SelectedRows[0].Cells[0].Value.ToString());
            if (!CheckIfBookAvailable(id_titlu))
            {
                MessageBox.Show("Ne pare rau!\n Nu mai avem nici un exemplar al acestui titlu disponibil!");
                return;
            }
            if (CheckIfAlreadyLoaned(id_abonat, id_titlu))
            {
                MessageBox.Show("Aceasta carte a fost imprumutata deja de catre acest client!\n Numai 1 exemplar de persoana este permis!");
                return;
            }
            _legBusinessLayer.ADDLoan(id_abonat, id_titlu);
            dgv_Loans.DataSource = _legBusinessLayer.GetLoansFor(id_abonat);
            tb_search_bookID.Text = null;
            btn_ADD_Loan.Enabled = false;
        }

        //View All Available books
        private void button3_Click(object sender, EventArgs e)
        {
            ShowAB();
            dgv_AB.DataSource = _legBusinessLayer.AvailableBooks();
        }

        //Search Available Books
        private void cBoxAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            tBoxAB.Show();
        }
        private void tBoxAB_TextChanged(object sender, EventArgs e)
        {
            switch (cBoxAB.Text.ToString())
            {
                case "Titlu":
                    dgv_AB.DataSource = _legBusinessLayer.SearchABByTitlu(tBoxAB.Text.ToString());
                    break;
                case "Autor":
                    dgv_AB.DataSource = _legBusinessLayer.SearchABByAutor(tBoxAB.Text.ToString());
                    break;
                case "Categorie":
                    dgv_AB.DataSource = _legBusinessLayer.SearchABByCategorie(tBoxAB.Text.ToString());
                    break;
                case "Editura":
                    dgv_AB.DataSource = _legBusinessLayer.SearchABByEditura(tBoxAB.Text.ToString());
                    break;
                default:
                    break;
            }
            if (tBoxAB.Text.ToString() == "")
                dgv_AB.DataSource = _legBusinessLayer.AvailableBooks();
        }


        //Clients->Manage
            //Design
        void RefreshClientEvidence()
        {
            dgv_regClients.DataSource = _legBusinessLayer.ViewAllRegisteredClients();
            dgv_Clients.DataSource = _legBusinessLayer.GetAbonati();
        }
        private void tabManage_Click(object sender, EventArgs e)
        { }
        private void LockClientTextBoxes()
        {
            tb_adresa.Enabled = false;
            tb_cnp.Enabled = false;
            tb_judet.Enabled = false;
            tb_localitate.Enabled = false;
            tb_nume.Enabled = false;
            tb_prenume.Enabled = false;
            tb_telefon.Enabled = false;
        }
        private void UnlockClientTextBoxes()
        {
            tb_adresa.Enabled = true;
            tb_cnp.Enabled = true;
            tb_judet.Enabled = true;
            tb_localitate.Enabled = true;
            tb_nume.Enabled = true;
            tb_prenume.Enabled = true;
            tb_telefon.Enabled = true;
        }
        private void EmptyTextBoxes()
        {
            tb_nume.Text = "";
            tb_prenume.Text = "";
            tb_adresa.Text = "";
            tb_localitate.Text = "";
            tb_judet.Text = "";
            tb_cnp.Text = "";
            tb_telefon.Text = "";
        }
        private void btn_AddClient_Click(object sender, EventArgs e)
        {
            if(tb_nume.Enabled == true)
            {
                MessageBox.Show("Numai o actiune permisa la un moment dat!\nVa rugam finalizati actiune in desfasurare sau apasati Cancel!");
                return; 
            }
            UnlockClientTextBoxes();
            btn_add.Show();
            btn_CancelClient.Show();
        }
        private void btn_editClient_Click(object sender, EventArgs e)
        {
            if (tb_nume.Enabled==true)
            {
                MessageBox.Show("Numai o actiune permisa la un moment dat!\nVa rugam finalizati actiune in desfasurare sau apasati Cancel!");
                return;
            }
            UnlockClientTextBoxes();
            btn_saveClient.Show();
            btn_CancelClient.Show();
            tb_nume.Text = dgv_regClients.SelectedRows[0].Cells[1].Value.ToString();
            tb_prenume.Text = dgv_regClients.SelectedRows[0].Cells[2].Value.ToString();
            tb_adresa.Text = dgv_regClients.SelectedRows[0].Cells[3].Value.ToString();
            tb_localitate.Text = dgv_regClients.SelectedRows[0].Cells[4].Value.ToString();
            tb_judet.Text = dgv_regClients.SelectedRows[0].Cells[5].Value.ToString();
            tb_cnp.Text = dgv_regClients.SelectedRows[0].Cells[6].Value.ToString();
            tb_telefon.Text = dgv_regClients.SelectedRows[0].Cells[7].Value.ToString();
        }
        private void btn_CancelClient_Click(object sender, EventArgs e)
        {
            EmptyTextBoxes();
            LockClientTextBoxes();
            btn_saveClient.Hide();
            btn_add.Hide();
            btn_CancelClient.Hide();
        }

            //Update Client
        private void btn_saveClient_Click(object sender, EventArgs e)
        {
            string nume = tb_nume.Text.ToString();
            string prenume = tb_prenume.Text.ToString();
            string adresa = tb_adresa.Text.ToString();
            string localitate = tb_localitate.Text.ToString();
            string judet = tb_judet.Text.ToString();
            string cnp = tb_cnp.Text.ToString();
            string telefon = tb_telefon.Text.ToString();
            int id = int.Parse(dgv_regClients.SelectedRows[0].Cells[0].Value.ToString());
            _legBusinessLayer.UpdateClient(id, nume, prenume, adresa, localitate, judet, cnp, telefon);
            EmptyTextBoxes();
            btn_saveClient.Hide();
            btn_CancelClient.Hide();
            LockClientTextBoxes();
            RefreshClientEvidence();
        }
            //Add Client
        private int getLastClientID()
        {
            int linie = dgv_Clients.Rows.Count - 2;
            int id = int.Parse(dgv_Clients.Rows[linie].Cells[0].Value.ToString());
            return id;
        }
        private bool VerifyClientTextBoxes()
        {
            if (tb_nume.Text.ToString() == "" || tb_prenume.Text.ToString() == "" || tb_adresa.Text.ToString() == "" || tb_localitate.Text.ToString() == "" || tb_judet.Text.ToString() == "" || tb_cnp.Text.ToString() == "" || tb_telefon.Text.ToString() == "")
                return false;
            string cnp = tb_cnp.Text.ToString();
            if (cnp.Length != 13)
                return false;
            string telefon = tb_telefon.Text.ToString();
            if (telefon.Length != 10)
                return false;
            return true;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            string nume = tb_nume.Text.ToString();
            string prenume = tb_prenume.Text.ToString();
            string adresa = tb_adresa.Text.ToString();
            string localitate = tb_localitate.Text.ToString();
            string judet = tb_judet.Text.ToString();
            string cnp = tb_cnp.Text.ToString();
            string telefon = tb_telefon.Text.ToString();
            int id = getLastClientID()+1;
            //verificare date introduse...
            if (VerifyClientTextBoxes())
            {
                if (_legBusinessLayer.AddClient(id, nume, prenume, adresa, localitate, judet, cnp, telefon))
                {
                    MessageBox.Show("Adaugarea a fost executata cu succes!");
                    EmptyTextBoxes();
                    btn_add.Hide();
                    btn_CancelClient.Hide();
                    LockClientTextBoxes();
                    RefreshClientEvidence();
                }
                else
                {
                    MessageBox.Show("Ne pare rau dar a intervenit o eroare la adaugarea clientului!\n Va rugam sa reincercati!");
                    EmptyTextBoxes();
                }
            }
                else
                {
                    MessageBox.Show("Datele introduse sunt incorecte!\n Va rugam sa reincercati!");
                    EmptyTextBoxes();
                }
        }

            //Delete Client
        private bool ExistLoanFor(int id)
        {
            bool exist = _legBusinessLayer.ExistLoanFor(id);
            return exist;
        }
        private void btn_deleteClient_Click(object sender, EventArgs e)
        {
            int id_Client=int.Parse(dgv_regClients.SelectedRows[0].Cells[0].Value.ToString());
            if (ExistLoanFor(id_Client))
                MessageBox.Show("Nu se pot Sterge din evidenta\nclienti care au carti imprumutate!");
            else
            {
                if (_legBusinessLayer.DeleteClient(id_Client))
                {
                    MessageBox.Show("Clientul a fost eliminat cu succes din baza de date!");
                    RefreshClientEvidence();
                }
                else
                    MessageBox.Show("A aparut o eroare la eliminarea clientului din baza de date!");
            }
        }





        //BOOKS
            
            //Design
        private bool CheckIfOtherActionInProgress()
        {
            if (tb_titlu.Enabled == true)
            {
                MessageBox.Show("Only one transaction permited at a time!\nPlease finish your curent transaction!");
                return true;
            }
            else
                return false;
        }
        private void btn_cancelBook_Click(object sender, EventArgs e)
        {
            LockBookTextBoxes();
            emptyBookBoxes();
            btn_add2.Hide();
            btn_saveBook.Hide();
            btn_cancelBook.Hide();
        }
        private void btn_editBook_Click(object sender, EventArgs e)
        {
            if (!CheckIfOtherActionInProgress())
            {
                UnlockBookTextBoxes();
                btn_saveBook.Show();
                btn_cancelBook.Show();
                int id_carte = int.Parse(dgv_BookEvidence.SelectedRows[0].Cells[0].Value.ToString());
                DataTable details = _legBusinessLayer.ViewBookDetails(id_carte);
                DataRow row = details.Rows[0];
                tb_titlu.Text = row["Titlu"].ToString();
                tb_editure.Text = row["Editura"].ToString();
                tb_nrpag.Text = row["Nr_Pagini"].ToString();
                tb_autor.Text = row["Nume Autor"].ToString();
                tb_pautor.Text = row["Prenume Autor"].ToString();
                tb_pret.Text = row["Pret_Cumparare"].ToString();
                tb_categorie.Text = row["Categorie"].ToString();
                tb_anAparitie.Text = row["An_Aparitie"].ToString();
                tb_nrExemplare.Text = row["Nr_Exemplare"].ToString();
                tb_autor.Enabled = false;
                tb_pautor.Enabled = false;
                tb_editure.Enabled = false;
            }
        }
        private void emptyBookBoxes()
        {
            tb_titlu.Text = "";
            tb_editure.Text = "";
            tb_nrpag.Text = "";
            tb_autor.Text = "";
            tb_pautor.Text = "";
            tb_pret.Text = "";
            tb_categorie.Text = "";
            tb_anAparitie.Text = "";
            tb_nrExemplare.Text = "";
        }
        private void btn_addBook_Click(object sender, EventArgs e)
        {
            if (!CheckIfOtherActionInProgress())
            {
                UnlockBookTextBoxes();
                btn_add2.Show();
                btn_cancelBook.Show();
            }
        }
        private void LockBookTextBoxes()
        {
            tb_titlu.Enabled = false;
            tb_editure.Enabled = false;
            tb_nrpag.Enabled = false;
            tb_autor.Enabled = false;
            tb_pautor.Enabled = false;
            tb_pret.Enabled = false;
            tb_categorie.Enabled = false;
            tb_anAparitie.Enabled = false;
            tb_nrExemplare.Enabled = false;
        }
        private void UnlockBookTextBoxes()
        {
            tb_titlu.Enabled = true;
            tb_editure.Enabled = true;
            tb_nrpag.Enabled = true;
            tb_autor.Enabled = true;
            tb_pautor.Enabled = true;
            tb_pret.Enabled = true;
            tb_categorie.Enabled = true;
            tb_anAparitie.Enabled = true;
            tb_nrExemplare.Enabled = true;
        }
           
            //Details
        private void btn_bookDetails_Click(object sender, EventArgs e)
        {
            int id=int.Parse(dgv_BookEvidence.SelectedRows[0].Cells[0].Value.ToString());
            dgv_bookDetails.DataSource = _legBusinessLayer.ViewBookDetails(id);
        }  
           
            //Insert Book
        private bool VerifyBooksTextBoxes()
        {
            if (tb_titlu.Text.ToString() == "" || tb_editure.Text.ToString() == "" || tb_nrpag.Text.ToString() == "" || tb_autor.Text.ToString() == "" || tb_pautor.Text.ToString() == "" || tb_pret.Text.ToString() == "" || tb_categorie.Text.ToString() == "" || tb_anAparitie.Text.ToString() == "" || tb_nrExemplare.Text.ToString() == "")
                return false;
            return true;
        }
        private int GetLastBookID()
        {
            int linie = dgv_BookEvidence.Rows.Count - 2;
            int id = int.Parse(dgv_BookEvidence.Rows[linie].Cells[0].Value.ToString());
            return id;
        }
        private void RefreshBookEvidence()
        {
            dgv_BookEvidence.DataSource= _legBusinessLayer.ViewAllBooks();
            dgv_AB.DataSource= _legBusinessLayer.AvailableBooks();
        }
        private int GetLastAutorID()
        {
            DataTable _autori = _legBusinessLayer.GetAutori();
            int nr_lastIndex = _autori.Rows.Count;
            return nr_lastIndex;
        }
        private int GetLastEdituraID()
        {
            DataTable _edituri = _legBusinessLayer.GetEdituri();
            int nr_lastIndex = _edituri.Rows.Count;
            return nr_lastIndex;
        }
        public bool ExistAutor(string nume,string prenume)
        {
            return _legBusinessLayer.ExistAutor(nume, prenume);
        }
        public bool ExistEditura(string denumire)
        {
            return _legBusinessLayer.ExistEditura(denumire);
        }
        private void AddExemplare(int id_carte,int nr_exemplare)
        {
            for (int i = 0; i < nr_exemplare; i++)
            {
                _legBusinessLayer.AddExemplar(id_carte);
            }
        }
        private void btn_add2_Click(object sender, EventArgs e)
        {
            if (!VerifyBooksTextBoxes())
            {
                MessageBox.Show("Nu lasati casute goale!");
                return;
            }
            string titlu = tb_titlu.Text.ToString();
            string editura = tb_editure.Text.ToString();
            int nrPag = int.Parse(tb_nrpag.Text.ToString());
            string autor = tb_autor.Text.ToString();
            string pautor = tb_pautor.Text.ToString();
            float pret = float.Parse(tb_pret.Text.ToString());
            string categorie = tb_categorie.Text.ToString();
            int anAparitie = int.Parse(tb_anAparitie.Text.ToString());
            int nrEx = int.Parse(tb_nrExemplare.Text.ToString());
            int id_carte = GetLastBookID() + 1;
            int id_autor;
            int id_editura;
            if (!ExistAutor(autor, pautor))
            {
                id_autor = GetLastAutorID() + 1;
                if (_legBusinessLayer.AddAutor(id_autor, autor, pautor))
                    MessageBox.Show("Autorul " + autor + " " + pautor + " a fost adaugat in baza de date pentru\n ca nu existau inregistrari anterioare ale acestuia!");
            }
            else
            {
                id_autor = _legBusinessLayer.GetAutorID(autor, pautor);
            } 
            if(!ExistEditura(editura))
            {
                id_editura = GetLastEdituraID() + 1;
                if (_legBusinessLayer.AddEditura(id_editura, editura))
                    MessageBox.Show("Editura " + editura + " a fost adaugata in baza de date deoarece nu existau inregistrati anterioare ale acesteia!");
            }
            else
            {
                id_editura = _legBusinessLayer.GetEdituraID(editura);
            }
            if (_legBusinessLayer.AddBook(id_carte, titlu, id_editura, nrPag, id_autor, pret, categorie, anAparitie, nrEx))
            {
                MessageBox.Show("Cartea a fost adaugata cu succes!");
                RefreshBookEvidence();
                LockBookTextBoxes();
                emptyBookBoxes();
                btn_add2.Hide();
                btn_cancelBook.Hide();
                AddExemplare(id_carte, nrEx);
            }
            else
            {
                MessageBox.Show("A intervenit o eroare la adaugarea noii carti!\nVa rugam reincercati!");
                emptyBookBoxes();
            }
        }

            //Update Book
        private void btn_saveBook_Click(object sender, EventArgs e)
        {
            if (!VerifyBooksTextBoxes())
            {
                MessageBox.Show("Nu lasati casute goale!");
                return;
            }
            string titlu = tb_titlu.Text.ToString();
            int nrPag = int.Parse(tb_nrpag.Text.ToString());           
            float pret = float.Parse(tb_pret.Text.ToString());
            string categorie = tb_categorie.Text.ToString();
            int anAparitie = int.Parse(tb_anAparitie.Text.ToString());
            int nrEx = int.Parse(tb_nrExemplare.Text.ToString());
            int id_carte = int.Parse(dgv_BookEvidence.SelectedRows[0].Cells[0].Value.ToString());
            int nrExInitial = _legBusinessLayer.CountExemplareFor(id_carte);
            if(nrExInitial!=nrEx)
            {
                if(nrEx>nrExInitial)
                {
                    int dif = nrEx - nrExInitial;
                    AddExemplare(id_carte, dif);
                }
                else
                {
                    _legBusinessLayer.DeleteExemplare(id_carte);
                    AddExemplare(id_carte, nrEx);
                }
            }
            _legBusinessLayer.UpdateBook(id_carte, titlu, nrPag, pret, categorie, anAparitie, nrEx);
            RefreshBookEvidence();
            LockBookTextBoxes();
            emptyBookBoxes();
            btn_saveBook.Hide();
            btn_cancelBook.Hide();
        }
            //Delete Book
        private void btn_DeleteBook_Click(object sender, EventArgs e)
        {
            int id_carte=int.Parse(dgv_BookEvidence.SelectedRows[0].Cells[0].Value.ToString());
            if (_legBusinessLayer.CheckIfBookIsLoaned(id_carte))
            {
                MessageBox.Show("Nu se poate sterge aceasta carte din evidenta \ndecat dupa ce au fost returnate toate exemplarele!\nEliminati imprumuturile aferente acestei carti!");
                return;
            }
            else
            {
                _legBusinessLayer.DeleteExemplare(id_carte);
                _legBusinessLayer.DeleteBook(id_carte);
                RefreshBookEvidence();
            }
        }



        //Users Management
        private string _username, _password;
        private int id_userCurent;
        public void SetCurentUser(string username, string password)
        {
            _username = username;
            _password = password;
            id_userCurent = _legBusinessLayer.GetUserID(_username, _password);
            label_username.Text = _username;
            SetPermissions();
        }

        private void btn_seeUserDetails_Click(object sender, EventArgs e)
        {
            UserDetails form = new UserDetails(id_userCurent);
            form.Show();
        }

        private void btn_changePassword_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword(id_userCurent,this);
            form.Show();
        }

        private void btn_changePermissions_Click(object sender, EventArgs e)
        {
            ChangePermissions form = new ChangePermissions(this,id_userCurent);
            form.Show();
        }

        private void btn_changeUsername_Click(object sender, EventArgs e)
        {
            ChangeUsername form = new ChangeUsername(id_userCurent, this);
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text.ToString())
            {
                case "ID":
                    dgv_regClients.DataSource= _legBusinessLayer.OrderClientsByID();
                    break;
                case "Nume":
                    dgv_regClients.DataSource = _legBusinessLayer.OrderClientsByNume();
                    break;
                case "Prenume":
                    dgv_regClients.DataSource = _legBusinessLayer.OrderClientsByPrenume();
                    break;
                case "Adresa":
                    dgv_regClients.DataSource = _legBusinessLayer.OrderClientsByAdresa();
                    break;
                case "Localitate":
                    dgv_regClients.DataSource = _legBusinessLayer.OrderClientsByLocalitate();
                    break;
                case "Judet":
                    dgv_regClients.DataSource = _legBusinessLayer.OrderClientsByJudet();
                    break;
                case "CNP":
                    dgv_regClients.DataSource = _legBusinessLayer.OrderClientsByCNP();
                    break;
                case "Telefon":
                    dgv_regClients.DataSource = _legBusinessLayer.OrderClientsByTelefon();
                    break;
                default:
                    break;
            }
        }

        public void RefreshCredentials()
        {
            _username = _legBusinessLayer.GetUsername(id_userCurent);
            _password = _legBusinessLayer.GetPassword(id_userCurent);
            label_username.Text = _username;
        }

        private void DisableAllButtons()
        {
            btn_seeUserDetails.Enabled = false;
            btn_changeUsername.Enabled = false;
            btn_changePassword.Enabled = false;
            btn_changePermissions.Enabled = false;
            btn_dLoan.Enabled = false;
            btn_ADD_Loan.Enabled = false;
            btn_viewAB.Enabled = false;
            btn_deleteClient.Enabled = false;
            btn_editClient.Enabled = false;
            btn_AddClient.Enabled = false;
            btn_DeleteBook.Enabled = false;
            btn_editBook.Enabled = false;
            btn_addBook.Enabled = false;
            btn_bookDetails.Enabled = false;
            btn_detailsAbonati.Enabled = false;
            btn_detailsCarti.Enabled = false;
            btn_detailsExemplare.Enabled = false;
            btn_detailsImprumuturi.Enabled = false;
            btn_detailsAB.Enabled = false;
            btn_detailsAutori.Enabled = false;
            btn_detailsEdituri.Enabled = false;
            btn_detailsLimit.Enabled = false;
        }
        public void SetPermissions()
        {
            DisableAllButtons();
            if (_legBusinessLayer.ExistPermission(id_userCurent, 0))
                btn_changePermissions.Enabled = true;
            if(_legBusinessLayer.ExistPermission(id_userCurent,1))
            {
                btn_seeUserDetails.Enabled = true;
                btn_viewAB.Enabled = true;
                btn_detailsAbonati.Enabled = true;
                btn_detailsCarti.Enabled = true;
                btn_detailsExemplare.Enabled = true;
                btn_detailsImprumuturi.Enabled = true;
                btn_detailsAB.Enabled = true;
                btn_detailsAutori.Enabled = true;
                btn_detailsEdituri.Enabled = true;
                btn_detailsLimit.Enabled = true;
                btn_bookDetails.Enabled = true;
            }
            if(_legBusinessLayer.ExistPermission(id_userCurent,2))
            {
                btn_changeUsername.Enabled = true;
                btn_changePassword.Enabled = true;
                btn_editClient.Enabled = true;
                btn_editBook.Enabled = true;
            }
            if (_legBusinessLayer.ExistPermission(id_userCurent, 3))
            {
                btn_ADD_Loan.Enabled = true;
                btn_AddClient.Enabled = true;
                btn_addBook.Enabled = true;
            }
            if (_legBusinessLayer.ExistPermission(id_userCurent, 4))
            {
                btn_dLoan.Enabled = true;
                btn_deleteClient.Enabled = true;
                btn_DeleteBook.Enabled = true;
            }
        }
    }
}
