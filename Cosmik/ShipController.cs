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
	class ShipController
	{
		public Ship ship;
		public bool Alive = true;
		Point pos;
		public PictureBox pb_ship;
		public PictureBox pb_bullet = new PictureBox();

		public ShipController(int x, int y, int t)
		{
			ship = new Ship(new Point(x, y),t);
			pos.X = x;
			pos.Y = y;
		}
		public void Draw(Panel panel)
		{
			pb_ship = new PictureBox();
			pb_ship.Size = new Size(50, 50);
			pb_ship.SizeMode = PictureBoxSizeMode.StretchImage;
			pb_ship.Image = ship.Body.image[1];
			pb_ship.BackColor = Color.Transparent;
			pb_ship.Location = new Point(pos.X, pos.Y);
			panel.Controls.Add(pb_ship);
		}
		
		public void Move(Keys key)
		{
			if (key == Keys.Left)
			{
				pb_ship.Image = ship.Body.image[3];
				if (pb_ship.Location.X > 2)
				{
					ship.Move(-1, 0, pb_ship);
				}
			}
			if (key == Keys.Up)
			{
				pb_ship.Image = ship.Body.image[0];
				if (pb_ship.Location.Y > 2)
				{
					ship.Move(0, -1, pb_ship);
				}
			}
			if (key == Keys.Right)
			{
				pb_ship.Image = ship.Body.image[1];
				if (pb_ship.Location.X < 505)
				{
					ship.Move(1, 0, pb_ship);
				}
			}
			if (key == Keys.Down)
			{
				pb_ship.Image = ship.Body.image[2];
				if (pb_ship.Location.Y < 270)
				{
					ship.Move(0, 1, pb_ship);
				}
			}
		}
		Point vector;
		public void Hit(Panel panel, Keys key)
		{
			vector = ship.Shoot(pb_bullet, panel, key);
			pb_bullet.BackColor = Color.Transparent;
		}
		public void Fly()
		{
			pb_bullet.Location = new Point(pb_bullet.Location.X + vector.X*ship.Bullet.range, pb_bullet.Location.Y + vector.Y*ship.Bullet.range);
		}
		public void TakeTurn()
		{
			 
		}
	}
}