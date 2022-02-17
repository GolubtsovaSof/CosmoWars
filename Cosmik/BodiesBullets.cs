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
	interface IShipBody
	{
		int hardness { get; }
		int weight { get; }
		List<Image> image { get; }
	}
	interface IBullet
	{
		int range { get; }
		int damage { get; }
		Image image { get; }
	}
	struct LightShipBody : IShipBody
	{
		public int hardness => 1;
		public int weight => 1;
		public List<Image> image => new List<Image>() { new Bitmap(Properties.Resources.HardbodyU), new Bitmap(Properties.Resources.HardbodyR), new Bitmap(Properties.Resources.HardbodyD), new Bitmap(Properties.Resources.HardbodyL) };
	}
	struct MiddleShipBody : IShipBody
	{
		public int hardness => 2;
		public int weight => 3;
		public List<Image> image => new List<Image>() { new Bitmap(Properties.Resources.MiddleBodyU), new Bitmap(Properties.Resources.MiddleBodyR), new Bitmap(Properties.Resources.MiddleBodyD), new Bitmap(Properties.Resources.MiddleBodyL) };
	}
	struct HardShipBody : IShipBody
	{
		public int hardness => 4;
		public int weight => 4;
		public List<Image> image => new List<Image>() { new Bitmap(Properties.Resources.LightBodyU), new Bitmap(Properties.Resources.LightBodyR), new Bitmap(Properties.Resources.LightBodyD), new Bitmap(Properties.Resources.LightBodyL) };
	}
	struct ELightShipBody : IShipBody
	{
		public int hardness => 1;
		public int weight => 1;
		public List<Image> image => new List<Image>() { new Bitmap(Properties.Resources.LightEnemy), new Bitmap(Properties.Resources.LightEnemyR), new Bitmap(Properties.Resources.LightEnemyD), new Bitmap(Properties.Resources.LightEnemyL) };
	}
	struct EMiddleShipBody : IShipBody
	{
		public int hardness => 2;
		public int weight => 3;
		public List<Image> image => new List<Image>() { new Bitmap(Properties.Resources.MiddleEnemy), new Bitmap(Properties.Resources.MiddleEnemyR), new Bitmap(Properties.Resources.MiddleEnemyD), new Bitmap(Properties.Resources.MiddleEnemyL) };
	}
	struct EHardShipBody : IShipBody
	{
		public int hardness => 4;
		public int weight => 4;
		public List<Image> image => new List<Image>() { new Bitmap(Properties.Resources.HardEnemy), new Bitmap(Properties.Resources.HardEnemyR), new Bitmap(Properties.Resources.HardEnemyD), new Bitmap(Properties.Resources.HardEnemyL) };
	}
	struct LightBullet : IBullet
	{
		public int range => 40;
		public int damage => 8;
		public Image image => new Bitmap(Properties.Resources.LightBullet);
	}
	struct MiddleBullet : IBullet
	{
		public int range => 25;
		public int damage => 12;
		public Image image => new Bitmap(Properties.Resources.MiddleBullet);
	}
	struct HardBullet : IBullet
	{
		public int range => 15;
		public int damage => 16;
		public Image image => new Bitmap(Properties.Resources.HardBullet);
	}
}
