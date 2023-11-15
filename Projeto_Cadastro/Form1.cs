using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Projeto_Cadastro
{
    public partial class Form1 : Form
    {
        string MysqlClientString = "Server = localhost; Port = 3306;" +
"User Id = root; Database = bd_empresa; SSL Mode = 0";
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string dateTime = dt_cad.Text;
            string createddate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
            string sql = "INSERT INTO tb_cadastro(Codigo_ID, Data, Status, Nome_Peca, Tamanho, Peso, Volume, Quantidade, Quantidade_Minima, Valor_Compra, Valor_Venda, Data_Fab, Data_Val, Descricao, Unidade)" +
                "VALUES('" + txt_codigo.Text + "','" + createddate.ToString() + "','" + check_status.Checked + "','" + txt_nome.Text +
                 "','" + txt_tamanho.Text + "','" + txt_peso.Text + "','" + txt_volume.Text + "','" + txt_quantidade.Text + "','" + txt_quant_min.Text + "','" + txt_valorCompra.Text + "','" + txt_valorVenda.Text + "','" + dt_fab.Text + "','" + dt_val.Text + "','" + txt_descricao.Text + "','" + cmb_unidade.Text + "')";
            MySqlConnection conn = new MySqlConnection(MysqlClientString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Produto gravado com sucesso", "Alerta",
MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

     
    }
}
