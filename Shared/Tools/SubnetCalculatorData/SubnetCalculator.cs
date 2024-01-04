namespace ITBoxWeb.Shared.Tools.SubnetCalculatorData
{
	public class SubnetCalculator
	{
		public static Subnet[] Calculate(NetAddress startingAddr, List<int> hostReqs)
		{
			Subnet[] subnets = new Subnet[hostReqs.Count];
			NetAddress lastAddr = startingAddr;
			for (int i = 0; i < hostReqs.Count; i++)
			{
				Console.WriteLine(hostReqs[i]);
				int temp = (int)Math.Ceiling(Math.Log2(hostReqs[i]));
				Console.WriteLine(temp);
				subnets[i] = new Subnet(lastAddr, Subnet.netMaskFromCidr(temp));
				lastAddr = subnets[i].BroadcastAddress.incrementOne();
			}
			return subnets;
		}
	}
}
