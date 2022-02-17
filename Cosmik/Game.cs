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
	class Game
	{
		public List<ShipController> players = new List<ShipController>() { new ShipController(100, 100, 0), new ShipController(400, 200, 1) };
		public int active = 0;
		public int prev_active = 0;
		System.Media.SoundPlayer player1 = new System.Media.SoundPlayer();
		System.Media.SoundPlayer player2 = new System.Media.SoundPlayer();

		public Game()
		{
		}
		public void Draw(Panel panel)
		{
			foreach (ShipController ship in players)
			{
				ship.Draw(panel);
			}
		}
		public void NextTurn()
		{
			if (active == 0)
			{
				active = 1;
				prev_active = 0;
			}
			else
			{
				active = 0;
				prev_active = 1;
			}
		}
		public int CheckWin(Panel panel)
		{
			if (!players[0].Alive)
			{
				players[0].Alive = false;
				player2.SoundLocation = "Lose.wav";
				player2.Play();
				return 0;
			}
			if (!players[1].Alive)
			{
				players[1].Alive = false;
				player2.SoundLocation = "Win.wav";
				player2.Play();
				return 1;
			}
			return -1;
		}
		public void checkHit(Panel panel, ProgressBar pb1, ProgressBar pb2)
		{
			if (players[1].pb_ship.Bounds.IntersectsWith((players[0].pb_bullet.Bounds)))
			{
				player1.SoundLocation = "sound.wav";
				player1.Play();
				players[1].ship.GetHit(players[0].ship.Bullet);
				panel.Controls.Remove(players[0].pb_bullet);
				if (players[1].ship.Health > 0) pb2.Value = players[1].ship.Health;
				else
				{
					pb2.Value = 0;
					players[1].Alive = false;
				}
			}
			if (players[0].pb_ship.Bounds.IntersectsWith((players[1].pb_bullet.Bounds)))
			{
				player1.SoundLocation = "sound.wav";
				player1.Play();
				players[0].ship.GetHit(players[1].ship.Bullet);
				panel.Controls.Remove(players[1].pb_bullet);
				if (players[0].ship.Health > 0) pb1.Value = players[0].ship.Health;
				else
				{
					pb1.Value = 0;
					players[0].Alive = false;
				}
			}
			if ((players[0].pb_ship.Bounds.IntersectsWith((players[1].pb_ship.Bounds)))|| (players[1].pb_ship.Bounds.IntersectsWith((players[0].pb_ship.Bounds))))
			{
				players[0].Alive = false;
			}
		}
	}
}
