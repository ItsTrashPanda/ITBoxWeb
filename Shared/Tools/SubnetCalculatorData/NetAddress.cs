using System.Runtime.ConstrainedExecution;

namespace ITBoxWeb.Shared.Tools.SubnetCalculatorData
{
	public class NetAddress
	{
		public String address { get; private set; }
		public Byte[] byteAddress { get; private set; }
		public int intAddress { get; private set; }

		public NetAddress(Byte[] byteAddr)
		{
			byteAddress = byteAddr;
			address = byteAddr[0] + "." + byteAddr[1] + "." + byteAddr[2] + "." + byteAddr[3];
			intAddress = (byteAddr[0] << 24) | (byteAddr[1] << 16) | (byteAddr[2] << 8) | byteAddr[3];
		}

		public NetAddress(int intAddr)
		{
			intAddress = intAddr;
			byteAddress = new Byte[4];
			byteAddress[0] = (Byte) (intAddr >> 24);
			byteAddress[1] = (Byte) (intAddr >> 16);
			byteAddress[2] = (Byte) (intAddr >> 8);
			byteAddress[3] = (Byte) (intAddr);
			address = byteAddress[0] + "." + byteAddress[1] + "." + byteAddress[2] + "." + byteAddress[3];	
		}

		public NetAddress incrementOne()
		{
			return new NetAddress(((byteAddress[0] << 24) | (byteAddress[1] << 16) | (byteAddress[2] << 8) | byteAddress[3])+1);
		}

		public String ToString()
		{
			return address;
		}
	}
}
