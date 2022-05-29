namespace PostgreSqlDotnetCore.Views
{
    using Npgsql;
    using System;
    using System.Data;
    using System.Data.Common;

    public class DB
    {
        public static string connectionString = "Host=localhost;Username=postgres;Password=' ';Database=DB";
      
        
       public void con(out string conn)
        {
            conn = connectionString;
        }

        public void amountApp(string email, out int amount)
        {
            amount = 0;
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand($@"SELECT name FROM  public.""AspNetUserApplication"" WHERE email = '{email}';", npgSqlConnection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
            if (npgSqlDataReader.HasRows)
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    amount++;
            npgSqlConnection.Close();
        }

        public void addApp(string name, string ucode, string email)
        {
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
             NpgsqlCommand npgSqlCommand = new NpgsqlCommand($@"INSERT INTO public.""AspNetUserApplication""(email, name, ucode, date, view, edit) VALUES ('{email}', '{name}', '{ucode}', '{DateTime.Now:g}', '0', '1')", npgSqlConnection);
            npgSqlCommand.ExecuteNonQuery();
            npgSqlConnection.Close();
        }

        //public void appList(string email)
        //{
        //    string name = string.Empty;
        //    string ucode = string.Empty;
        //    string date = string.Empty;
        //    NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
        //    npgSqlConnection.Open();
        //    view(email);
        //    NpgsqlCommand comm = new NpgsqlCommand
        //    {
        //        Connection = npgSqlConnection,
        //        CommandType = CommandType.Text,
        //        CommandText = $@"SELECT name, ucode, date FROM public.""AspNetUserApplication"" WHERE email = '{email}';"
               
        //    };
        //    NpgsqlDataReader dr = comm.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //      foreach (DbDataRecord dbDataRecord in dr)
        //        {
        //            name = dbDataRecord["name"].ToString();
        //            ucode = dbDataRecord["ucode"].ToString();
        //            date = dbDataRecord["date"].ToString();
        //        }
                   
        //    }
        //    comm.Dispose();
        //    npgSqlConnection.Close();
        //}
        //public void CheckUCode(string ucode, out bool check)
        //{
        //    check = false;
        //    NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
        //    npgSqlConnection.Open();
        //    NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT ucode FROM app Where ucode = '{ucode}'", npgSqlConnection);
        //    NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
        //    if (npgSqlDataReader.HasRows)
        //        check = true;
        //    npgSqlConnection.Close();
        //}

        public void statsApp(string email, out int view, out int edit)
        {
            view = 1; edit = 1;
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand($@"SELECT view, edit FROM public.""AspNetUserApplication"" WHERE email = '{email}';", npgSqlConnection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
            if (npgSqlDataReader.HasRows)
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    if(view < int.Parse(dbDataRecord["view"].ToString()) && edit < int.Parse(dbDataRecord["edit"].ToString()))
                         view = int.Parse(dbDataRecord["view"].ToString()); edit += int.Parse(dbDataRecord["edit"].ToString());
       
                }

            npgSqlConnection.Close();
        }

        public void view(string email)
        {
            int view = 0;
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand($@"SELECT view FROM public.""AspNetUserApplication"" WHERE email = '{email}';", npgSqlConnection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
            if (npgSqlDataReader.HasRows)
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                        view = int.Parse(dbDataRecord["view"].ToString());
            addview(email, view);
        }

        public void addview(string email, int view)
        {
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlCommand npgSqlCommand2 = new NpgsqlCommand($@"UPDATE ""AspNetUserApplication"" SET view = {view+1} WHERE email = '{email}';", npgSqlConnection);
            npgSqlCommand2.ExecuteNonQuery();
            npgSqlConnection.Close();
        }
    }
}
