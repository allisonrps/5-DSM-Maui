﻿using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;


namespace MauiMYSQL.Models
{
    public class Conecta
    {

        public string conexao_status { get; set; }
        public string StrQuery { get; set; }
        public string StrCon { get; set; }
        public MySqlDataReader Dr;
        public MySqlCommand Cmd;
        public MySqlConnection Conn;


        public Conecta()
        {
        }

        public bool Conexao()
        {
            //StrCon = "host=192.168.1.250;port=3306;user=fukuta;password=#abc123456;";
            MySqlConnectionStringBuilder StrCon = new MySqlConnectionStringBuilder();

            StrCon.Server = "scoreviewbackend.westus2.cloudapp.azure.com"; // conexao interna na rede
            StrCon.Port = 3306;
            StrCon.UserID = "allisonrps";
            StrCon.Password = "fatecfranca123#";
            StrCon.Database = "MINHA_API";

            Conn = new MySqlConnection(StrCon.ToString());
            bool ret = false;
            try
            {
                Conn.Open();
                conexao_status = "Conexão realizada com sucesso !";
                ret = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                conexao_status = ex.Message;
                ret = false;
            }




            return ret;
        }


    }
}
