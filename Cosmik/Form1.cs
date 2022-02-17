using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmik
{
	public partial class Form1 : Form
	{
		Keys key = Keys.Right;
		Keys AI_key = Keys.Right;
		int AI_Space = 0;
		Game game = new Game();
		List<Keys> k = new List<Keys>() { Keys.Right, Keys.Down, Keys.Left, Keys.Up, Keys.Space };
		Random rnd = new Random();
		public Form1()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			game.Draw(panel1);
			progressBar1.Value = 100;
			progressBar2.Value = 100;

		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Down)
			{
				key = e.KeyCode;
				timer1.Start();
				timer2.Start();
				timer3.Start();
				
			}
			if (e.KeyCode == Keys.Space)
			{
				if (game.active == 0)
				{
					game.players[game.active].Hit(panel1, key);
					game.NextTurn();
					timer1.Start();
					timer4.Start();
					timer2.Start();
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			game.players[0].Move(key);
			game.players[1].Move(AI_key);
			if (game.active==1 && AI_Space==1)
			{
				game.players[game.active].Hit(panel1, AI_key);
				game.NextTurn();
				AI_Space = 0;
			}
			if (game.active == 0)
			{
				panel2.BackColor = Color.LightSteelBlue;
				panel3.BackColor = Color.Gray;
			}
			else
			{
				panel3.BackColor = Color.LightSteelBlue;
				panel2.BackColor = Color.Gray;
			}
		}

		private void timer2_Tick_1(object sender, EventArgs e)
		{
			if(game.players[0].pb_bullet.Image!=null) game.players[0].Fly();
			if (game.players[1].pb_bullet.Image != null) game.players[1].Fly();
			game.checkHit(panel1,progressBar1,progressBar2);

			if (game.CheckWin(panel1) != -1)
			{
				panel1.Controls.Remove(game.players[0].pb_ship);
				panel1.Controls.Remove(game.players[1].pb_ship);
				panel1.Controls.Remove(game.players[0].pb_bullet);
				panel1.Controls.Remove(game.players[1].pb_bullet);
				progressBar1.Value = 100;
				progressBar2.Value = 100;
				game = new Game();
				game.Draw(panel1);
				timer1.Stop();
				key = Keys.Right;
			}
		}

		private void timer3_Tick(object sender, EventArgs e)
		{
			AI_key = k[rnd.Next(0, 4)];
		}

		private void timer4_Tick(object sender, EventArgs e)
		{
			AI_Space = rnd.Next(0, 2);
		}
	}
}
