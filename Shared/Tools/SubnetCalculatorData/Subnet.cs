namespace ITBoxWeb.Shared.Tools.SubnetCalculatorData
{
	public class Subnet
	{
		public NetAddress NetAddress { get; private set; }
		public NetAddress NetMask { get; private set; }
		public int cidr { get; private set; }
		public NetAddress FirstHostAddress { get; private set; }
		public NetAddress LastHostAddress { get; private set; }
		public NetAddress BroadcastAddress { get; private set; }
		public int HostsCount { get; private set; }
		
		public Subnet(NetAddress netAddr, NetAddress netMask)
		{
			NetAddress = netAddr;
			NetMask = netMask;
			cidr = cidrFromNetMask(NetMask);
			Console.WriteLine(netMask.intAddress);
			BroadcastAddress = new NetAddress(netAddr.intAddress + ~netMask.intAddress);
			Console.WriteLine(netMask.intAddress);
			FirstHostAddress = netAddr.incrementOne();
			LastHostAddress = new NetAddress(BroadcastAddress.intAddress - 1);
			HostsCount = ~netMask.intAddress - 1;
			Console.WriteLine(netMask.intAddress);
		}

		public Subnet(NetAddress netAddr, int cidr)
		{
			NetAddress = netAddr;
			this.cidr = cidr;
			NetMask = netMaskFromCidr(cidr);
			BroadcastAddress = new NetAddress(netAddr.intAddress | ~NetMask.intAddress);
			FirstHostAddress = netAddr.incrementOne();
			LastHostAddress = new NetAddress(BroadcastAddress.intAddress - 1);
			HostsCount = LastHostAddress.intAddress - FirstHostAddress.intAddress + 1;
		}

		public static int cidrFromNetMask(NetAddress mask)
		{
			int cid = 0;
			for (int i = 0; i < 32; i++)
			{
				if ((mask.intAddress & (1 << i)) != 0)
				{
					cid++;
				}
			}
			return cid;
		}

		public static NetAddress netMaskFromCidr(int cid)
		{
			int mask = 0;
			for (int i = 0; i < cid; i++)
			{
				mask |= 1 << (i);
			}
			return new NetAddress(~mask);
		}
	}
}
