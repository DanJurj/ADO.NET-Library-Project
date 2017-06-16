using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class BusinessLayer
    {
        private DataLayer _legDataLayer = new DataLayer();
        public BusinessLayer()
        { }

        //Statistics
        public DataTable GetBooks()
        {
            DataTable _tabRet = _legDataLayer.SelectData("SELECT Carti.ID_Carte,Carti.Titlu,Autori.Nume+' '+Autori.Prenume as [Nume Autor] From Carti Inner Join Autori On Carti.ID_Autor=Autori.ID_Autor", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public string SearchByCNP(string CNP)
        {
            string res = string.Empty;
            res = _legDataLayer.SelectDataBy("SELECT Nume From Abonati Where CNP=@CNP", CommandType.Text, new List<SqlParameter> { new SqlParameter("@CNP", CNP) });
            return res;
        }
        public int CountAbonati()
        {
            int _result = _legDataLayer.CountData("Select Count(Distinct ID) From Abonati", CommandType.Text, new List<SqlParameter>());
            return _result;
        }
        public int CountCarti()
        {
            int _result = _legDataLayer.CountData("Select Count(Distinct ID_Carte) From Carti", CommandType.Text, new List<SqlParameter>());
            return _result;
        }
        public int CountExemplare()
        {
            int _result = _legDataLayer.CountData("Select Count(Distinct ID_Exemplar) From Exemplare", CommandType.Text, new List<SqlParameter>());
            return _result;
        }
        public int CountImprumuturi()
        {
            int _result = _legDataLayer.CountData("Select Count(*) From Imprumuturi", CommandType.Text, new List<SqlParameter>());
            return _result;
        }
        public int CountAB()
        {
            int _result = _legDataLayer.CountData("Select COUNT(ID_Carte) From Carti Where Nr_Exemplare>(Select COUNT(*) From Imprumuturi Where ID_Exemplar in (Select ID_Exemplar From Exemplare Where Exemplare.ID_Carte=Carti.ID_Carte))", CommandType.Text, new List<SqlParameter>());
            return _result;
        }
        public int CountAutori()
        {
            int _result = _legDataLayer.CountData("Select Count(DISTINCT ID_Autor) From Autori", CommandType.Text, new List<SqlParameter>());
            return _result;
        }
        public int CountEdituri()
        {
            int _result = _legDataLayer.CountData("Select Count(DISTINCT ID_Editura) From Edituri", CommandType.Text, new List<SqlParameter>());
            return _result;
        }
        public DataTable GetAbonati()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select ID,Nume+' '+Prenume as Numele From Abonati", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable GetCarti()
        {
            DataTable _tabRet = _legDataLayer.SelectData("SELECT Carti.ID_Carte,Carti.Titlu,Autori.Nume+' '+Autori.Prenume as [Nume Autor] From Carti Inner Join Autori On Carti.ID_Autor=Autori.ID_Autor", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable GetExemplare()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select Titlu,Nr_Exemplare From Carti", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable GetImprumuturi()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select Abonati.Nume,Carti.Titlu From Abonati  Inner Join Imprumuturi On Abonati.ID=Imprumuturi.ID_Abonat Inner Join Exemplare On Imprumuturi.ID_Exemplar=Exemplare.ID_Exemplar Inner Join Carti On Exemplare.ID_Carte=Carti.ID_Carte", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable GetAB()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select Titlu From Carti Where Nr_Exemplare>(Select COUNT(*) From Imprumuturi Where ID_Exemplar in (Select ID_Exemplar From Exemplare Where Exemplare.ID_Carte=Carti.ID_Carte))", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable GetAutori()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select ID_Autor,Nume+' '+Prenume as [Numele Autorului] From Autori", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable GetEdituri()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select ID_Editura,Denumire,Localitate From Edituri", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public int CountDelays(int nr_days)
        {
            int _result = _legDataLayer.CountData("GetNrDelays", CommandType.StoredProcedure, new List<SqlParameter>() { new SqlParameter("@maxDays", nr_days) });
            return _result;
        }
        public DataTable GetDelays(int nr_days)
        {
            DataTable _tabRet = _legDataLayer.SelectData("GetDetailsDelays", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@maxDays", nr_days) });
            return _tabRet;
        }
        public DataTable GetName(int id)
        {
            DataTable _tabRet = _legDataLayer.SelectData("GetNames", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id", id) });
            return _tabRet;
        }
        public int CountExemplareFor(int id)
        {
            SqlParameter p_id = new SqlParameter("@id_carte", id);
            return _legDataLayer.CountData("CountExemplareFor", CommandType.StoredProcedure, new List<SqlParameter> { p_id });
        }

        //Clients
        public DataTable GetClients()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select ID, Nume, Prenume,Cnp From Abonati", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable GetLoansFor(int id_user)
        {
            DataTable _tabRet = _legDataLayer.SelectData("GetLoansFor", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_user", id_user) });
            return _tabRet;
        }
        public bool DeleteLoan(int id_abonat, string titlu)
        {
            return _legDataLayer.DeleteRow("DeleteLoan", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_abonat", id_abonat), new SqlParameter("@titlu", titlu) });
        }
        public bool CheckIfBookAvailable(int id)
        {
            int nr = _legDataLayer.CountData("CountAvailable", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id", id) });
            if (nr > 0)
                return true;
            else
                return false;
        }
        public bool CheckIfAlreadyLoaned(int id_abonat, int id_carte)
        {
            int nr = _legDataLayer.CountData("CountAlreadyLoaned", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_abonat", id_abonat), new SqlParameter("@id_carte", id_carte) });
            if (nr > 0)
                return true;
            else
                return false;
        }
        public bool ADDLoan(int id_abonat, int id_titlu)
        {
            return _legDataLayer.InsertRow("ADDLoan", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_abonat", id_abonat), new SqlParameter("@id_titlu", id_titlu) });
        }
        //Search Clients
        public DataTable SearchClientsByName(string nume)
        {
            DataTable _tabRet = _legDataLayer.SelectData("SearchClientsByNume", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@nume", nume) });
            return _tabRet;
        }
        public DataTable SearchClientsByPrenume(string prenume)
        {
            DataTable _tabRet = _legDataLayer.SelectData("SearchClientsByPrenume", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@prenume", prenume) });
            return _tabRet;
        }
        public DataTable SearchClientsByCNP(string CNP)
        {
            DataTable _tabRet = _legDataLayer.SelectData("SearchClientsByCNP", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@CNP", CNP) });
            return _tabRet;
        }


        //Available books
        public DataTable AvailableBooks()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select ID_Carte,Titlu,Nume+' '+Prenume as [Numele autorului],Carti.Nr_Exemplare-(Select COUNT(*) From Imprumuturi Where ID_Exemplar in (Select ID_Exemplar From Exemplare Where Exemplare.ID_Carte=Carti.ID_Carte)) as [Nr Exemplare Disponibile] From Carti,Autori Where Nr_Exemplare>(Select COUNT(*) From Imprumuturi Where ID_Exemplar in (Select ID_Exemplar From Exemplare Where Exemplare.ID_Carte=Carti.ID_Carte)) and Carti.ID_Autor=Autori.ID_Autor", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        //Search Available books
        public DataTable SearchABByTitlu(string titlu)
        {
            DataTable _tabRet = _legDataLayer.SelectData("SearchABByTitlu", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@titlu", titlu) });
            return _tabRet;
        }
        public DataTable SearchABByAutor(string numeAutor)
        {
            DataTable _tabRet = _legDataLayer.SelectData("SearchABByAutor", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@numeAutor", numeAutor) });
            return _tabRet;
        }
        public DataTable SearchABByCategorie(string categorie)
        {
            DataTable _tabRet = _legDataLayer.SelectData("SearchABByCategorie", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@categorie", categorie) });
            return _tabRet;
        }
        public DataTable SearchABByEditura(string numeEditura)
        {
            DataTable _tabRet = _legDataLayer.SelectData("SearchABByEditura", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@numeEditura", numeEditura) });
            return _tabRet;
        }


        //Clients->Manage
        public DataTable ViewAllRegisteredClients()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public bool AddClient(int id, string nume, string prenume, string adresa, string localitate, string judet, string cnp, string telefon)
        {
            SqlParameter p_id = new SqlParameter("@id", id);
            SqlParameter p_nume = new SqlParameter("@nume", nume);
            SqlParameter p_prenume = new SqlParameter("@prenume", prenume);
            SqlParameter p_adresa = new SqlParameter("@adresa", adresa);
            SqlParameter p_localitate = new SqlParameter("@localitate", localitate);
            SqlParameter p_judet = new SqlParameter("@judet", judet);
            SqlParameter p_cnp = new SqlParameter("@cnp", cnp);
            SqlParameter p_telefon = new SqlParameter("@telefon", telefon);
            return _legDataLayer.InsertRow("ADDClient", CommandType.StoredProcedure, new List<SqlParameter> { p_id, p_nume, p_prenume, p_adresa, p_localitate, p_judet, p_cnp, p_telefon });
        }
        public bool ExistLoanFor(int id_abonat)
        {
            int nrLoans = _legDataLayer.CountData("ExistLoansFor", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_abonat", id_abonat) });
            if (nrLoans > 0)
                return true;
            else
                return false;
        }
        public bool DeleteClient(int id_abonat)
        {
            return _legDataLayer.DeleteRow("DeleteClient", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_abonat", id_abonat) });
        }
        public bool UpdateClient(int id, string nume, string prenume, string adresa, string localitate, string judet, string cnp, string telefon)
        {
            SqlParameter p_id = new SqlParameter("@id", id);
            SqlParameter p_nume = new SqlParameter("@nume", nume);
            SqlParameter p_prenume = new SqlParameter("@prenume", prenume);
            SqlParameter p_adresa = new SqlParameter("@adresa", adresa);
            SqlParameter p_localitate = new SqlParameter("@localitate", localitate);
            SqlParameter p_judet = new SqlParameter("@judet", judet);
            SqlParameter p_cnp = new SqlParameter("@cnp", cnp);
            SqlParameter p_telefon = new SqlParameter("@telefon", telefon);
            return _legDataLayer.UpdateRow("UpdateClient", CommandType.StoredProcedure, new List<SqlParameter> { p_id, p_nume, p_prenume, p_adresa, p_localitate, p_judet, p_cnp, p_telefon });
        }


        //Books
        public DataTable ViewAllBooks()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select ID_Carte,Titlu,Denumire as [Editura],Nume as [Nume Autor],Prenume as [Prenume Autor] From Carti,Edituri,Autori Where Carti.ID_Editura=Edituri.ID_Editura and Carti.ID_Autor=Autori.ID_Autor", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable ViewBookDetails(int id)
        {
            DataTable _tabRet = _legDataLayer.SelectData("ViewBookDetails", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id", id) });
            return _tabRet;
        }
        public bool ExistAutor(string nume, string prenume)
        {
            SqlParameter p_nume = new SqlParameter("@nume", nume);
            SqlParameter p_prenume = new SqlParameter("@prenume", prenume);
            return _legDataLayer.ExistRow("ExistAutor", CommandType.StoredProcedure, new List<SqlParameter> { p_nume, p_prenume });
        }
        public bool AddAutor(int id, string nume, string prenume)
        {
            SqlParameter p_id = new SqlParameter("@id", id);
            SqlParameter p_nume = new SqlParameter("@nume", nume);
            SqlParameter p_prenume = new SqlParameter("@prenume", prenume);
            return _legDataLayer.InsertRow("ADDAutor", CommandType.StoredProcedure, new List<SqlParameter> { p_id, p_nume, p_prenume });
        }
        public bool ExistEditura(string denumire)
        {
            SqlParameter p_denumire = new SqlParameter("@editura", denumire);
            return _legDataLayer.ExistRow("ExistEditura", CommandType.StoredProcedure, new List<SqlParameter> { p_denumire });
        }
        public bool AddEditura(int id, string denumire)
        {
            SqlParameter p_id = new SqlParameter("@id", id);
            SqlParameter p_denumire = new SqlParameter("@editura", denumire);
            return _legDataLayer.InsertRow("ADDEditura", CommandType.StoredProcedure, new List<SqlParameter> { p_id, p_denumire });
        }
        public int GetAutorID(string nume, string prenume)
        {
            SqlParameter p_nume = new SqlParameter("@nume", nume);
            SqlParameter p_prenume = new SqlParameter("@prenume", prenume);
            return _legDataLayer.CountData("GetAutorID", CommandType.StoredProcedure, new List<SqlParameter> { p_nume, p_prenume });
        }
        public int GetEdituraID(string denumire)
        {
            SqlParameter p_denumire = new SqlParameter("@denumire", denumire);
            return _legDataLayer.CountData("GetEdituraID", CommandType.StoredProcedure, new List<SqlParameter> { p_denumire });
        }
        public bool AddBook(int id_carte, string titlu, int id_editura, int nr_pag, int id_autor, float Pret, string categorie, int anAparitie, int nrExemplare)
        {
            SqlParameter p_id = new SqlParameter("@id_carte", id_carte);
            SqlParameter p_titlu = new SqlParameter("@titlu", titlu);
            SqlParameter p_idEditura = new SqlParameter("@id_editura", id_editura);
            SqlParameter p_nrPag = new SqlParameter("@nrPag", nr_pag);
            SqlParameter p_idAutor = new SqlParameter("@id_autor", id_autor);
            SqlParameter p_pret = new SqlParameter("@pret", Pret);
            SqlParameter p_categorie = new SqlParameter("@categorie", categorie);
            SqlParameter p_an = new SqlParameter("@an", anAparitie);
            SqlParameter p_nrex = new SqlParameter("@nrex", nrExemplare);
            return _legDataLayer.InsertRow("ADDBook", CommandType.StoredProcedure, new List<SqlParameter> { p_id, p_titlu, p_idEditura, p_nrPag, p_idAutor, p_pret, p_categorie, p_an, p_nrex });
        }
        public void AddExemplar(int id_carte)
        {
            SqlParameter p_id = new SqlParameter("@id", id_carte);
            _legDataLayer.InsertRow("ADDExemplar", CommandType.StoredProcedure, new List<SqlParameter> { p_id });
        }

        //Delete Book
        public bool CheckIfBookIsLoaned(int id_carte)
        {
            return _legDataLayer.ExistRow("CheckIfBookIsLoaned", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_carte", id_carte) });
        }
        public void DeleteExemplare(int id_carte)
        {
            _legDataLayer.DeleteRow("DeleteExemplare", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_carte", id_carte) });
        }
        public bool DeleteBook(int id_carte)
        {
            return _legDataLayer.DeleteRow("DeleteBook", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id_carte", id_carte) });
        }

        //Update Book
        public bool UpdateBook(int id, string titlu, int nrPag, float pret, string categorie, int anAparitie, int nrEx)
        {
            SqlParameter p_id = new SqlParameter("@id_carte", id);
            SqlParameter p_titlu = new SqlParameter("@titlu", titlu);
            SqlParameter p_nrPag = new SqlParameter("@nrPag", nrPag);
            SqlParameter p_pret = new SqlParameter("@pret", pret);
            SqlParameter p_categorie = new SqlParameter("@categorie", categorie);
            SqlParameter p_anAparitie = new SqlParameter("@anAparitie", anAparitie);
            SqlParameter p_nrEx = new SqlParameter("@nrEx", nrEx);
            return _legDataLayer.UpdateRow("UpdateBook", CommandType.StoredProcedure, new List<SqlParameter> { p_id, p_titlu, p_nrPag, p_pret, p_categorie, p_anAparitie, p_nrEx });
        }




        //User Management
        public bool CheckCredentials(string username, string pass)
        {
            SqlParameter p_username = new SqlParameter("@username", username);
            SqlParameter p_pass = new SqlParameter("@password", pass);
            return _legDataLayer.ExistRow("Select Count(*) From Users Where UserName=@username and Password=Hashbytes('MD5',@password)", CommandType.Text, new List<SqlParameter> { p_username, p_pass });
        }
        public bool NotUniqueUsername(string username)
        {
            SqlParameter p_username = new SqlParameter("@username", username);
            return _legDataLayer.ExistRow("Select Count(*) From Users Where UserName=@username", CommandType.Text, new List<SqlParameter> { p_username });
        }
        public bool CreateNewUser(string nume, string prenume, string cnp, string username, string password)
        {
            SqlParameter p_nume = new SqlParameter("@nume", nume);
            SqlParameter p_prenume = new SqlParameter("@prenume", prenume);
            SqlParameter p_cnp = new SqlParameter("@cnp", cnp);
            SqlParameter p_username = new SqlParameter("@username", username);
            SqlParameter p_password = new SqlParameter("@password", password);
            bool val=_legDataLayer.InsertRow("ADDUser", CommandType.StoredProcedure, new List<SqlParameter> { p_nume, p_prenume, p_cnp, p_username, p_password });
            return val;
        }
        public bool AddPermission(int id_user, int id_permisiune)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            SqlParameter p_idPermisiune = new SqlParameter("@id_permisiune", id_permisiune);
            return _legDataLayer.InsertRow("ADDPermission", CommandType.StoredProcedure, new List<SqlParameter> { p_idUser, p_idPermisiune });
        }
        public bool ChangePassword(int id_user, string newPass)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            SqlParameter p_newPass = new SqlParameter("@newPass", newPass);
            return _legDataLayer.UpdateRow("Update Users Set Password=Hashbytes('MD5',@newPass) Where ID=@id_user", CommandType.Text, new List<SqlParameter> { p_idUser, p_newPass });
        }
        public bool RemovePermission(int id_user, int id_permisiune)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            SqlParameter p_idPermisiune = new SqlParameter("@id_permisiune", id_permisiune);
            return _legDataLayer.DeleteRow("RemovePermission", CommandType.StoredProcedure, new List<SqlParameter> { p_idUser, p_idPermisiune });
        }
        public bool ExistPermission(int id_user, int id_permisiune)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            SqlParameter p_idPermisiune = new SqlParameter("@id_permisiune", id_permisiune);
            return _legDataLayer.ExistRow("ExistPermission", CommandType.StoredProcedure, new List<SqlParameter> { p_idUser, p_idPermisiune });
        }
        public bool ChangeUsername(int id_user, string newUsername)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            SqlParameter p_newUsername = new SqlParameter("@newUsername", newUsername);
            return _legDataLayer.UpdateRow("Update Users Set UserName=@newUsername Where ID=@id_user", CommandType.Text, new List<SqlParameter> { p_idUser, p_newUsername });
        }
        public DataTable GetUserDetails(int id_user)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            DataTable _tabRet = _legDataLayer.SelectData("Select UserName, Nume, Prenume, CNP From Users Where ID=@id_user", CommandType.Text, new List<SqlParameter> { p_idUser });
            return _tabRet;
        }
        public DataTable GetUserPermissions(int id_user)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            DataTable _tabRet = _legDataLayer.SelectData("GetUserPermissions", CommandType.StoredProcedure, new List<SqlParameter> { p_idUser });
            return _tabRet;
        }
        public DataTable GetUser()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select UserName, Nume, Prenume, CNP From Users", CommandType.Text, new List<SqlParameter> { });
            return _tabRet;
        }
        public int GetUserID(string username, string pass)
        {
            SqlParameter p_username = new SqlParameter("@username", username);
            SqlParameter p_pass = new SqlParameter("@password", pass);
            return _legDataLayer.CountData("Select ID from Users Where UserName=@username and Password=Hashbytes('MD5',@password)", CommandType.Text, new List<SqlParameter> { p_username, p_pass });
        }
        public string GetUsername(int id_user)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            return _legDataLayer.GetData("Select UserName From Users Where ID=@id_user", CommandType.Text, new List<SqlParameter> { p_idUser });
        }
        public string GetPassword(int id_user)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            return _legDataLayer.GetData("Select Password From Users Where ID=@id_user", CommandType.Text, new List<SqlParameter> { p_idUser });
        }
        public DataTable GetUser2()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select UserName From Users", CommandType.Text, new List<SqlParameter> { });
            return _tabRet;
        }
        public int GetUserID2(string username)
        {
            SqlParameter p_username = new SqlParameter("@username", username);
            return _legDataLayer.CountData("Select ID from Users Where UserName=@username", CommandType.Text, new List<SqlParameter> { p_username });
        }
        public void RemoveAllPermissions(int id_user)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            _legDataLayer.DeleteRow("Delete from PermisiuniAcordate Where ID_User=@id_user", CommandType.Text, new List<SqlParameter> { p_idUser });
        }
        public void RemoveUser(int id_user)
        {
            SqlParameter p_idUser = new SqlParameter("@id_user", id_user);
            _legDataLayer.DeleteRow("Delete from Users Where ID=@id_user", CommandType.Text, new List<SqlParameter> { p_idUser });
        }

        //Order Clients
        public DataTable OrderClientsByID()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by ID", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable OrderClientsByNume()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by Nume", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable OrderClientsByPrenume()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by Prenume", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable OrderClientsByAdresa()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by Adresa", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable OrderClientsByLocalitate()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by Localitate", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable OrderClientsByJudet()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by Judet", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable OrderClientsByCNP()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by CNP", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
        public DataTable OrderClientsByTelefon()
        {
            DataTable _tabRet = _legDataLayer.SelectData("Select * From Abonati Order by Telefon", CommandType.Text, new List<SqlParameter>());
            return _tabRet;
        }
    }
}
