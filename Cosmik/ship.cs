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
	class Ship
	{
		public IShipBody Body;
		public IBullet Bullet;
		
		public int Health = 100;
		int Speed = 5;
		Point Position;
		Random rnd = new Random(DateTime.Now.Millisecond);

		public Ship(Point p, int x)
		{
			Position = p;
			if(x==0) Body = shipBodies[rnd.Next(0, 3)];
			if(x==1) Body = shipBodies[rnd.Next(3, 6)];
			Speed += Body.weight;
		}
		public void Move(int x, int y, PictureBox pb)
		{
			Position.X += x*Speed;
			Position.Y += y*Speed;
			pb.Location = new Point(Position.X, Position.Y);
		}
		public void GetHit(IBullet hittingBullet)
		{
			Health -= hittingBullet.damage/Body.hardness;
		}
		public Point Shoot(PictureBox pb_bullet, Panel panel, Keys key)
		{
			Reload();
			pb_bullet.Image = Bullet.image;
			pb_bullet.Size = new Size(10, 10);
			pb_bullet.SizeMode = PictureBoxSizeMode.StretchImage;
			int x0 = 0;
			int y0 = 0;
			if (key == Keys.Right)
			{
				pb_bullet.Location = new Point(Position.X + 50, Position.Y + 50 / 2 - 5);
				x0 = 1;
			}
			if (key == Keys.Left)
			{
				pb_bullet.Location = new Point(Position.X-10, Position.Y + 50 / 2 - 5);
				x0 = -1;
			}
			if (key == Keys.Up)
			{
				pb_bullet.Location = new Point(Position.X + 50 / 2 - 5, Position.Y-10);
				y0 = -1;
			}
			if (key == Keys.Down)
			{
				pb_bullet.Location = new Point(Position.X + 50 / 2 - 5, Position.Y + 50);
				y0 = 1;
			}
			panel.Controls.Add(pb_bullet);
			Point res = new Point(x0, y0);
			return res;
		}
		public void Reload()
		{
			Bullet = Bullets[rnd.Next(0, 3)];
		}
		List<IShipBody> shipBodies = new List<IShipBody> { new LightShipBody(), new MiddleShipBody(), new HardShipBody(), new ELightShipBody(), new EMiddleShipBody(), new EHardShipBody()};
		List<IBullet> Bullets = new List<IBullet> { new LightBullet(), new MiddleBullet(), new HardBullet() };
	}
}
