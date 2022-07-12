using System.Threading.Tasks;

namespace Sample105
{
	public class Startup
	{
		int x = 0;
		public async Task<object> Invoke(object input)
		{
			x += (int)input;
			return x;
		}

		public async Task<object> Invoke2(object input)
		{
			return "Felix";
		}

		int Add7(int v) 
		{
			return Helper.Add7(v);
		}
	}

	static class Helper
	{
		public static int Add7(int v)
		{
			return v + 7;
		}
	}
}