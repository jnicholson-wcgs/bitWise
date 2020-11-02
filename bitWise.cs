using System;


/* 
 * Class to mask data
 */
class testMask {
  public uint d, m, e;

  public testMask (uint data, uint mask, uint expected) { 
    d = data;
    m = mask; 
    e = expected;
  }
}

class testIP {
  public uint d;
  public string e;

  public testIP (uint ip, string ipAddress)
  {
    this.d = ip;
    this.e = ipAddress;
  }
}

class MainClass {

  public static uint undefined = 0xdeadbeef;

  public static void Main (string[] args) {
    Console.WriteLine ("Complete the stub functions below");
    testMasks();
  }

/*
 * maskAnd()
 * Parameters: data and mask
 * Return: data bitwise ANDed with mask 
 */
  public static uint maskAnd (uint data, uint mask) {
    return undefined;
  }

/*
 * maskOr()
 * Parameters: data and mask
 * Return: data bitwise ORed with mask 
 */
  public static uint maskOr (uint data, uint mask) 
  {
    return undefined;
  }
/*
 * bitSet (data, bitNo)
 * Set the bit referenced by bitNo in data and return the result.
 * E.g., bitSet (0xf0, 0) will set bit 0 and return 0xf1
 */
  public static uint bitSet (uint data, int bitNo) {
    return undefined;
  }

  /*
 * bitClear (data, bitNo)
 * Clear the bit referenced by bitNo in data and return the result.
 * E.g., bitClear (0xf1, 0) will clear bit 0 and return 0xf0
 */
  public static uint bitClear (uint data, int bitNo) {
    return undefined;
  }

  /*
 * bitFlip (data, bitNo)
 * bitFlip the bit referenced by bitNo in data and return the result.
 * E.g., bitFlip (0xf1, 0) will flip bit 0 and return 0xf0
 * bitFlip (0xf0, 0) will flip bit 0 and return 0xf1
 * bitFlip (bitFlip (0xf1), 0) will return 0xf1
 */
  public static uint bitFlip (uint data, int bitNo) {
    return undefined;
  }

/*
 * crc(byte[], length)
 * crc returns the CRC checksum for length of data
 */

public static byte crc (byte[] b, int l) {

  return 0xde;
}
 /*
  * host (unit ipaddress, unit netmask)
  * returns the host from the IP address given.
  */

public static uint host  (uint ip, uint netmask) {
  return 0xff;
}

/*
 * network (unit ipaddress, uint netmask)
 * return the network for the IP address given
 */

public static uint network (uint ip, uint netmask) {
  return 0xffffff00;
}
/*
 * ipaddress (unit ip)
 * return a string corresponding to the ip address passed in 
 * ipaddress (0xC0A80001) will return "192.168.0.1"
 */

 public static string ipaddress (uint ip) {
   return ("No cheating");
 }

/*
 * Run the test scripts
 * Not documented on purpose......
 */
 
  public static void testMasks() {

    int score = 0;
    int count = 0;
    uint expected;

    /* AND test */ 
    testMask [] andTests = {
      new testMask (0xdeadbeef, 0xffff, 0xbeef),
      new testMask (0xdeadbeef, 0xffff0000, 0xdead0000)
    };

    foreach (var t in andTests) {
      count++;
      if ((expected = maskAnd (t.d, t.m)) == t.e)
        score++;
      else 
        Console.WriteLine ("maskAnd: ({0:X}, {1:X} expected {2:X}, got {3:x}", t.d, t.m, t.e, expected);
    }

    testMask [] orTests = {
      new testMask (0xbad1dea, 0x0, 0xbad1dea),
      new testMask (0xbad0000, 0x1dea, 0xbad1dea)
    };

    foreach (var t in orTests) {
      count++;
      if ((expected = maskOr (t.d, t.m)) == t.e)
        score++;
      else 
        Console.WriteLine ("maskOr: ({0:X}, {1:X} expected {2:X}, got {3:x}", t.d, t.m, t.e, expected);
    }

    testMask [] bitSetTests = {
      new testMask (0x0, 0, 0x1),
      new testMask (0x011, 2, 0x15),
      new testMask (0xbad1dea, 31, 0x8bad1dea)
    };

    foreach (var t in bitSetTests) {
      count++;
      if ((expected = bitSet (t.d, (int)t.m)) == t.e)
        score++;
      else 
        Console.WriteLine ("bitSet: ({0:X}, {1:X} expected {2:X}, got {3:x}", t.d, t.m, t.e, expected);
    }

    testMask [] bitClearTests = {
      new testMask (0x011, 2, 0x11),
      new testMask (0xbad1dea, 12, 0xbad0dea),
      new testMask (0xdeadbeef, 31, 0x5eadbeef)
    };

    foreach (var t in bitClearTests) {
      count++;
      if ((expected = bitClear (t.d, (int)t.m)) == t.e)
        score++;
      else 
        Console.WriteLine ("bitClear: ({0:X}, {1:X} expected {2:X}, got {3:x}", t.d, t.m, t.e, expected);
    }

    testMask [] bitFlipTests = {
      new testMask (0x011, 2, 0x15),
      new testMask (0x15, 2, 0x11),
      new testMask (0xdeadbeef, 31, 0x5eadbeef)
    };

    foreach (var t in bitFlipTests) {
      count++;
      if ((expected = bitFlip (t.d, (int)t.m)) == t.e)
        score++;
      else 
        Console.WriteLine ("bitFlip: ({0:X}, {1:X} expected {2:X}, got {3:x}", t.d, t.m, t.e, expected);
    }

    byte [][] t1 =  {
      new byte[] {0x20,0x21,0xff,0xe1, 0x1f},
      new byte[] {0xde, 0xad, 0xbe, 0xef, 0x22}
     } ;

     foreach (var bstream in t1) {
       count++;
       if (crc (bstream, 5) == 0)
        score++;
      else
        Console.WriteLine ("Non-zero checksum for {0}", bstream);   
  
     }
    
    testMask [] IPHosts = {
      new testMask (0xC0A80001, 0xffffff00, 0x1),
      new testMask (0xC0A80125, 0xfffff800, 0x125)

    };

    foreach (var t in IPHosts) {
      count++;
      if ((expected = host (t.d, t.m)) == t.e)
        score++;
      else 
        Console.WriteLine ("host(): ({0:X}, {1:X} expected {2:X}, got {3:x}", t.d, t.m, t.e, expected);
    }

    foreach (var t in IPHosts) {
      count++;
      if ((expected = network (t.d, t.m)) == (t.d & t.m))
        score++;
      else 
        Console.WriteLine ("network(): ({0:X}, {1:X} expected {2:X}, got {3:x}", t.d, t.m, (t.d & t.m), expected);
    }

    testIP [] IPAddresses = {
      new testIP (0xC0A80001, "192.168.0.1"),
      new testIP (0xC0A80025, "192.168.0.37")
    };

    foreach (var t in IPAddresses) {
      count++;
      string expectStr;
      if ((expectStr = ipaddress (t.d)) == t.e)
        score++;
      else 
        Console.WriteLine ("ipaddress(): ({0:X} expected {1}, got {2}", t.d, t.e, expectStr);
    }

    double percentage = ((double)score / (double)count) * 100;
    Console.WriteLine ("Score = {0} out of {1} = {2:F}%", score, count, percentage);
  }


}

   
