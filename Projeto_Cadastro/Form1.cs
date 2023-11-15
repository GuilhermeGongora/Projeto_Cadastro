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
            if (txt_codigo.Text == "")
            {
                MessageBox.Show("Não foi possível cadastrar!", "Alerta",
MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                string dateTimeFab = dt_fab.Text;
                string dateTimeVal = dt_val.Text;
                string dateTimeCad = dt_cad.Text;
                string createTimeFab = Convert.ToDateTime(dateTimeFab).ToString("yyyy-MM-dd");
                string createTimeVal = Convert.ToDateTime(dateTimeVal).ToString("yyyy-MM-dd");
                string createTimeCad = Convert.ToDateTime(dateTimeCad).ToString("yyyy-MM-dd");
                string sql = "INSERT INTO tb_cadastro(Codigo_ID, Data, Status, Nome_Peca, Tamanho, Peso, Volume, Quantidade, Quantidade_Minima, Valor_Compra, Valor_Venda, Data_Fab, Data_Val, Descricao, Unidade)" +
                    "VALUES('" + txt_codigo.Text + "','" + createTimeCad.ToString() + "','" + cmb_Status.Text + "','" + txt_nome.Text +
                     "','" + txt_tamanho.Text + "','" + txt_peso.Text + "','" + txt_volume.Text + "','" + txt_quantidade.Text + "','" + txt_quant_min.Text + "','" + txt_valorCompra.Text + "','" + txt_valorVenda.Text + "','" + createTimeFab.ToString() + "','" + createTimeVal.ToString() + "','" + txt_descricao.Text + "','" + cmb_unidade.Text + "')";
                MySqlConnection conn = new MySqlConnection(MySqlClientString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto gravado com sucesso", "Alerta",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
					}

        private void btn_Pesquisar_Nome_Click(object sender, EventArgs e)
        {
            try
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
                txt_codigo.Text = dt.Rows[0].Field<int>("Codigo_ID").ToString();
                dt_cad.Text =  dt.Rows[0].Field<DateTime>("Data").ToString();
                cmb_Status.Text = dt.Rows[0].Field<string>("Status");
                txt_nome.Text = dt.Rows[0].Field<string>("Nome_Peca");
                txt_tamanho.Text = dt.Rows[0].Field<double>("Tamanho").ToString();
                txt_peso.Text = dt.Rows[0].Field<double>("Peso").ToString();
                txt_volume.Text = dt.Rows[0].Field<double>("Volume").ToString();
                txt_quantidade.Text = dt.Rows[0].Field<int>("Quantidade").ToString();
                txt_quant_min.Text = dt.Rows[0].Field<int>("Quantidade_Minima").ToString();
                txt_valorCompra.Text = dt.Rows[0].Field<double>("Valor_Compra").ToString();
                txt_valorVenda.Text = dt.Rows[0].Field<double>("Valor_venda").ToString();
                dt_fab.Text = dt.Rows[0].Field<DateTime>("Data_Fab").ToString();
                dt_val.Text = dt.Rows[0].Field<DateTime>("Data_Val").ToString();
                txt_descricao.Text = dt.Rows[0].Field<string>("Descricao");
                cmb_unidade.Text = dt.Rows[0].Field<string>("Unidade");
            }
            catch 
            {           
                MessageBox.Show("Produto não cadastrado!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                //btn_novo_Click)btn_novo, e);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE FROM tb_cadastro WHERE Codigo_ID = '" + txt_codigo.Text + "'";
                MySqlConnection conn = new MySqlConnection(MySqlClientString);
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Peça deletada com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btn_novo_Click)btn_novo, e);
            }
            catch
            {
                MessageBox.Show("Não foi possível deletar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            conn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter
            ("SELECT * from tb_cadastro", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 400;
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_codigo.Clear();
            txt_descricao.Clear();
            txt_nome.Clear();
            txt_peso.Clear();
            txt_quantidade.Clear();
            txt_quant_min.Clear();
            txt_tamanho.Clear();
            txt_valorCompra.Clear();
            txt_valorVenda.Clear();
            txt_volume.Clear();
            dt_cad.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dt_fab.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dt_val.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmb_Status.Text = "Selecione...";
            cmb_unidade.Text = "Selecione...";
            nome_Peca_Pesquisa.Text = "";
            dataGridView1.Columns.Clear();
            txt_codigo.Focus();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string dateTimeFab = dt_fab.Text;
                string dateTimeVal = dt_val.Text;
                string dateTimeCad = dt_cad.Text;
                string createTimeFab = Convert.ToDateTime(dateTimeFab).ToString("yyyy-MM-dd");
                string createTimeVal = Convert.ToDateTime(dateTimeVal).ToString("yyyy-MM-dd");
                string createTimeCad = Convert.ToDateTime(dateTimeCad).ToString("yyyy-MM-dd");
                string sql = "UPDATE tb_cadastro SET Data = '" + createTimeCad.ToString() + "', Status = '" + cmb_Status.Text + "', Nome_Peca = '" + txt_nome.Text + "', Tamanho = '" + txt_tamanho.Text +
                    "', Peso = '" + txt_peso.Text + "', Volume = '" + txt_volume.Text + "', Quantidade = '" + txt_quantidade.Text + "', Quantidade_Minima = '"
                    + txt_quant_min.Text + "', Valor_Compra = '" + txt_valorCompra.Text + "', Valor_Venda = '" + txt_valorVenda.Text + "', Data_Fab = '" + createTimeFab.ToString() + "', Data_Val = '" + createTimeVal.ToString() + "', Descricao = '" + txt_descricao.Text
                    + "', Unidade = '" + cmb_unidade.Text + "' WHERE Codigo_ID = '" + txt_codigo.Text + "'";
                MySqlConnection conn = new MySqlConnection(MySqlClientString);
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Peça alterada com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btn_novo_Click)btn_novo, e);
            }
            catch
            {
                MessageBox.Show("Não foi possível alterar o filme", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
