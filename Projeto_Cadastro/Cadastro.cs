using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Projeto_Cadastro
{
	public partial class Cadastro : Form
	{
		string MySqlClientString = "Server = localhost; Port = 3306;" +
"User Id = root; Database = bd_empresa; SSL Mode = 0; convert zero datetime=True";
		public Cadastro()
		{
			InitializeComponent();
		}

        private void btn_insert_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txt_codigo.Text == "" || txt_Cod_For.Text == "" || txt_Razao.Text == "" || lbl_fantasia.Text == "")
                {
                    MessageBox.Show("Não foi possível cadastrar!", "Alerta",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sql = "INSERT INTO tb_cadastro(Codigo_ID, Codigo_FOR, Nome_Razao, Nome_Fts, Data, Status, Nome_Peca, Tamanho, Peso, Volume, Quantidade, Quantidade_Minima, Valor_Compra, Valor_Venda, Data_Fab, Data_Val, Descricao, Unidade)" +
                        "VALUES('" + txt_codigo.Text + "','" + txt_Cod_For.Text + "','" + txt_Razao.Text + "','" + txt_Fantasia.Text + "','" + dt_cad.Text + "','" + cmb_Status.Text + "','" + txt_nome.Text +
                         "','" + txt_tamanho.Text + "','" + txt_peso.Text + "','" + txt_volume.Text + "','" + txt_quantidade.Text + "','" + txt_quant_min.Text + "','" + txt_valorCompra.Text + "','" + txt_valorVenda.Text + "','" + dt_fab.Text + "','" + dt_val.Text + "','" + txt_descricao.Text + "','" + cmb_unidade.Text + "')";
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
            catch
            {
                MessageBox.Show("Não foi possível cadastra", "Alerta",
   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
            
        }

        private void btn_Pesquisar_Nome_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MySqlClientString);
                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tb_cadastro WHERE Nome_Peca LIKE  '" + nome_Peca_Pesquisa.Text + "%'", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                txt_codigo.Text = dt.Rows[0].Field<int>("Codigo_ID").ToString();
                txt_Cod_For.Text = dt.Rows[0].Field<int>("Codigo_FOR").ToString();
                txt_Razao.Text = dt.Rows[0].Field<string>("Nome_Razao").ToString();
                txt_Fantasia.Text = dt.Rows[0].Field<string>("Nome_Fts").ToString();
                dt_cad.Text = dt.Rows[0].Field<DateTime>("Data").ToString();
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
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txt_codigo.Text == "")
                {
                    MessageBox.Show("Não foi possível deletar", "Alerta",
    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sql = "DELETE FROM tb_cadastro WHERE Codigo_ID = '" + txt_codigo.Text + "'";
                    MySqlConnection conn = new MySqlConnection(MySqlClientString);
                    MySqlCommand cmd = new MySqlCommand();
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Peça deletada com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível deletar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_select_Click_1(object sender, EventArgs e)
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

        private void btn_update_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE tb_cadastro SET Nome_Razao = '" + txt_Razao.Text+ "', Nome_Fts = '" + txt_Fantasia.Text  + "', Data = '" + dt_cad.Text + "', Status = '" + cmb_Status.Text + "', Nome_Peca = '" + txt_nome.Text + "', Tamanho = '" + txt_tamanho.Text +
                    "', Peso = '" + txt_peso.Text + "', Volume = '" + txt_volume.Text + "', Quantidade = '" + txt_quantidade.Text + "', Quantidade_Minima = '"
                    + txt_quant_min.Text + "', Valor_Compra = '" + txt_valorCompra.Text + "', Valor_Venda = '" + txt_valorVenda.Text + "', Data_Fab = '" +dt_fab.Text + "', Data_Val = '" + dt_val.Text + "', Descricao = '" + txt_descricao.Text
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

        private void btn_limpar_Click_1(object sender, EventArgs e)
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

              private void pct_Insert_Click(object sender, EventArgs e)
        {
           try
            { 
                MySqlConnection conn = new MySqlConnection(MySqlClientString);
                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tb_cadastro WHERE Nome_Razao LIKE  '" + txt_Search_Razao.Text + "%'", conn);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                txt_codigo.Text = dt.Rows[0].Field<int>("Codigo_ID").ToString();
                txt_Cod_For.Text = dt.Rows[0].Field<int>("Codigo_FOR").ToString();
                txt_Razao.Text = dt.Rows[0].Field<string>("Nome_Razao").ToString();
                txt_Fantasia.Text = dt.Rows[0].Field<string>("Nome_Fts").ToString();
                dt_cad.Text = dt.Rows[0].Field<DateTime>("Data").ToString();
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
        }

        private void btn_carregar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            conn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter
            ("SELECT * FROM tb_cadastro", conn);
            da.Fill(dt);
            dgv_lista.DataSource = dt;
            dgv_lista.Columns[0].Width = 100;
            dgv_lista.Columns[1].Width = 200;
            dgv_lista.Columns[2].Width = 200;
            dgv_lista.Columns[3].Width = 200;
            dgv_lista.Columns[4].Width = 200;
            dgv_lista.Columns[5].Width = 400;
        }

       
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.WindowState = FormWindowState.Maximized;

        }
        int i = 0;
        Image imagem;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            conn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tb_cadastro", conn);
            da.Fill(dt);
            try
            {
                imagem = Image.FromFile(@"fotos\" + dt.Rows[i].Field<int>("Codigo_ID").ToString() + ".png");
            }
            catch
            {
                Font fonte = new Font("Times New Roman", 26, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Relatório Geral de Filmes", fonte, Brushes.Black, 280, 10);
                e.Graphics.DrawString("Máquina - Peças  - Indústria - Empilhadeiras", fonte, Brushes.Black, 200, 50);
                e.Graphics.DrawString("Data de emissão do relatório: " + DateTime.Now.ToString("dd/MM/yyyy"),
               fonte, Brushes.Black, 260, 90);
                e.Graphics.DrawString("_______________________________________________________________",
                fonte, Brushes.Black, 50, 110);

                e.Graphics.DrawImage(pic_image.Image = imagem, 180, 150, 450, 300);
                e.Graphics.DrawString("Código: " + dt.Rows[i].Field<int>("Codigo_ID").ToString(), fonte, Brushes.Black, 50, 500);
                e.Graphics.DrawString("Código_For: " + dt.Rows[i].Field<int>("Codigo_FOR").ToString(), fonte, Brushes.Black, 50, 550);
                e.Graphics.DrawString("Nome_Razao: " + dt.Rows[i].Field<string>("Nome_Razao").ToString(), fonte, Brushes.Black, 50, 600);
                e.Graphics.DrawString("Nome_Fts: " + dt.Rows[i].Field<string>("Nome_Fts").ToString(), fonte, Brushes.Black, 50, 650);
                e.Graphics.DrawString("Data: " + dt.Rows[i].Field<DateTime>("Data").ToString(), fonte, Brushes.Black, 50, 700);
                e.Graphics.DrawString("Status: " + dt.Rows[i].Field<string>("Status"), fonte, Brushes.Black, 50, 750);
                e.Graphics.DrawString("Nome Peça: " + dt.Rows[i].Field<string>("Nome_Peca"), fonte, Brushes.Black, 50, 800);
                e.Graphics.DrawString("Tamanho: " + dt.Rows[i].Field<double>("Tamanho").ToString(), fonte, Brushes.Black, 50, 850);
                e.Graphics.DrawString("Peso: " + dt.Rows[i].Field<double>("Peso").ToString(), fonte, Brushes.Black, 50, 900);
                e.Graphics.DrawString("Volume: " + dt.Rows[i].Field<double>("Volume").ToString(), fonte, Brushes.Black, 50, 950);
                e.Graphics.DrawString("Quantidade: " + dt.Rows[i].Field<int>("Quantidade").ToString(), fonte, Brushes.Black, 50, 1000);
                e.Graphics.DrawString("Quantidade_Mínima: " + dt.Rows[i].Field<int>("Quantidade_Minima").ToString(), fonte, Brushes.Black, 350, 500);
                e.Graphics.DrawString("Valor de Compra: " + dt.Rows[i].Field<double>("Valor_Compra").ToString(), fonte, Brushes.Black, 350, 550);
                e.Graphics.DrawString("Valor de Venda: " + dt.Rows[i].Field<double>("Valor_venda").ToString(), fonte, Brushes.Black, 350, 600);
                e.Graphics.DrawString("Data de Fabricação: " + dt.Rows[i].Field<DateTime>("Data_Fab").ToString(), fonte, Brushes.Black, 350, 650);
                e.Graphics.DrawString("Data de Validade: " + dt.Rows[i].Field<DateTime>("Data_Val").ToString(), fonte, Brushes.Black, 350, 700);
                e.Graphics.DrawString("Descrição: \n" + dt.Rows[i].Field<string>("Descricao"), fonte, Brushes.Black, 350, 750);
                e.Graphics.DrawString("Unidade: " + dt.Rows[i].Field<string>("Unidade"), fonte, Brushes.Black, 350, 850);
                if (i < (dt.Rows.Count - 1))
                {
                    i++;
                    e.HasMorePages = true;
                }
            }
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            i = 0;
            printPreviewDialog1.ShowDialog();
        }

        private void btn_pesquisar_titulo_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MySqlClientString);
                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tb_cadastro WHERE Nome_Peca LIKE  '" + nome_Peca_Pesquisa.Text + "%'", conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                txt_codigo.Text = dt.Rows[0].Field<int>("Codigo_ID").ToString();
                txt_Cod_For.Text = dt.Rows[0].Field<int>("Codigo_FOR").ToString();
                txt_Razao.Text = dt.Rows[0].Field<string>("Nome_Razao").ToString();
                txt_Fantasia.Text = dt.Rows[0].Field<string>("Nome_Fts").ToString();
                dt_cad.Text = dt.Rows[0].Field<DateTime>("Data").ToString();
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dgv_lista.Columns.Clear();
            txt_pesquisar.Clear();
            txt_pesquisar.Focus();
            btn_carregar.Image = Properties.Resources.giro;
            btn_relatorio.Image = Properties.Resources.impressora_estatico;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = Msg_Exit.Show();
            if (dialogo == DialogResult.Yes)
                Application.Exit();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = Msg_Exit.Show();
            if (dialogo == DialogResult.Yes)
                Application.Exit();
        }

        private void btn_Pesquisar_Nome_MouseMove(object sender, MouseEventArgs e)
        {
            btn_Pesquisar_Nome.Size = new Size(50, 50);
        }

        private void btn_Pesquisar_Nome_MouseLeave(object sender, EventArgs e)
        {
            btn_Pesquisar_Nome.Size = new Size(40, 40);

        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = Msg_Exit3.Show();
            if (dialogo == DialogResult.Yes)
                Application.Exit();
        }

        private void pct_Insert_MouseMove(object sender, MouseEventArgs e)
        {
            pct_Insert.Size = new Size(50, 50);
        }

        private void pct_Insert_MouseLeave(object sender, EventArgs e)
        {
            pct_Insert.Size = new Size(40, 40);

        }

              private void btn_carregar_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void btn_carregar_MouseDown(object sender, MouseEventArgs e)
        {
            btn_carregar.Image = Properties.Resources.load_animado_unscreen;
        }

        private void btn_relatorio_MouseDown(object sender, MouseEventArgs e)
        {
            btn_relatorio.Image = Properties.Resources.impressora;
        }
    }
}
