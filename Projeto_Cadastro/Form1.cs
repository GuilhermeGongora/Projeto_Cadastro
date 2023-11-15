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
		string MySqlClientString = "Server = localhost; Port = 3306;" +
"User Id = root; Database = bd_empresa; SSL Mode = 0; convert zero datetime=True";
		public Form1()
		{
			InitializeComponent();
		}
		private void btn_insert_Click(object sender, EventArgs e)
		{
			string dateTimeFab = dt_fab.Text;
			string dateTimeVal = dt_val.Text;
			string dateTimeCad = dt_cad.Text;
			string createTimeFab = Convert.ToDateTime(dateTimeFab).ToString("yyyy-MM-dd");
            string createTimeVal = Convert.ToDateTime(dateTimeVal).ToString("yyyy-MM-dd");
            string createTimeCad = Convert.ToDateTime(dateTimeCad).ToString("yyyy-MM-dd");
            string sql = "INSERT INTO tb_cadastro(Codigo_ID, Data, Status, Nome_Peca, Tamanho, Peso, Volume, Quantidade, Quantidade_Minima, Valor_Compra, Valor_Venda, Data_Fab, Data_Val, Descricao, Unidade)" +
				"VALUES('" + txt_codigo.Text + "','" + createTimeCad.ToString() + "','" + cmb_Status.Text + "','" + txt_nome.Text +
				 "','" + txt_tamanho.Text + "','" + txt_peso.Text + "','" + txt_volume.Text + "','" + txt_quantidade.Text + "','" + txt_quant_min.Text + "','" + txt_valorCompra.Text + "','" + txt_valorVenda.Text + "','" + createTimeFab.ToString() + "','" + createTimeVal.ToString()+ "','" + txt_descricao.Text + "','" + cmb_unidade.Text + "')";
			MySqlConnection conn = new MySqlConnection(MySqlClientString);
			conn.Open();
			MySqlCommand cmd = new MySqlCommand();
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			MessageBox.Show("Produto gravado com sucesso", "Alerta",
MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private void btn_Pesquisar_Nome_Click(object sender, EventArgs e)
        {
            string dateTimeFab = dt_fab.Text;
            string dateTimeVal = dt_val.Text;
            string dateTimeCad = dt_cad.Text;
            string createTimeFab = Convert.ToDateTime(dateTimeFab).ToString("yyyy-MM-dd");
            string createTimeVal = Convert.ToDateTime(dateTimeVal).ToString("yyyy-MM-dd");
            string createTimeCad = Convert.ToDateTime(dateTimeCad).ToString("yyyy-MM-dd");
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tb_cadastro WHERE Nome_Peca LIKE  '" + nome_Peca_Pesquisa.Text + "%'", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                txt_cod.Text = dt.Rows[0].Field<int>("Codigo_ID").ToString();
                createTimeCad = dt.Rows[0].Field<DateTime>("Data").ToString();
                cmb_Status.Text = dt.Rows[0].Field<string>("Status");
                txt_nome.Text = dt.Rows[0].Field<string>("Nome_Peca");
                txt_tamanho.Text = dt.Rows[0].Field<double>("Tamanho").ToString();
                txt_peso.Text = dt.Rows[0].Field<double>("Peso").ToString();
                txt_volume.Text = dt.Rows[0].Field<double>("Volume").ToString();
                txt_quantidade.Text = dt.Rows[0].Field<int>("Quantidade").ToString();
                txt_quant_min.Text = dt.Rows[0].Field<int>("Quantidade_Minima").ToString();
                txt_valorCompra.Text = dt.Rows[0].Field<double>("Valor_Compra").ToString();
                txt_valorVenda.Text = dt.Rows[0].Field<double>("Valor_venda").ToString();
                createTimeFab = dt.Rows[0].Field<DateTime>("Data_Fab").ToString();
                createTimeVal = dt.Rows[0].Field<DateTime>("Data_Val").ToString();
                txt_descricao.Text = dt.Rows[0].Field<string>("Descricao");
                cmb_unidade.Text = dt.Rows[0].Field<string>("Unidade");
                //btn_novo_Click)btn_novo, e);
                MessageBox.Show("Produto não cadastrado!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
