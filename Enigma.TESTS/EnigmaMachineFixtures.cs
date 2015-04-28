using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enigma.TESTS
{
   
    [TestClass]
    public class EnigmaMachineFixtures
    {
     
        [TestMethod]
        [TestCategory("Buildup")]
        public void Can_Create_EnigmaMachine()
        {
            try
            {
                //var machine = EnigmaMachine.Create();

                //var reflector = Rotor.Create("dumy".ToCharArray());
                //var rotor1 = Rotor.Create("abcd".ToCharArray());
                //var rotor2 = Rotor.Create("abcd".ToCharArray());

                ////set up reflector mapping;
                //Node.Connect(reflector.RotorPoints[0].RightNode, reflector.RotorPoints[3].RightNode);
                //Node.Connect(reflector.RotorPoints[1].RightNode, reflector.RotorPoints[2].RightNode);

                ////wire up rotor1;
                //Node.Connect(rotor1.RotorPoints[0].LeftNode, rotor1.RotorPoints[3].RightNode);
                //Node.Connect(rotor1.RotorPoints[1].LeftNode, rotor1.RotorPoints[1].RightNode);
                //Node.Connect(rotor1.RotorPoints[2].LeftNode, rotor1.RotorPoints[0].RightNode);
                //Node.Connect(rotor1.RotorPoints[3].LeftNode, rotor1.RotorPoints[2].RightNode);

                ////wire up rotor2;
                //Node.Connect(rotor2.RotorPoints[0].LeftNode, rotor2.RotorPoints[3].RightNode);
                //Node.Connect(rotor2.RotorPoints[1].LeftNode, rotor2.RotorPoints[1].RightNode);
                //Node.Connect(rotor2.RotorPoints[2].LeftNode, rotor2.RotorPoints[0].RightNode);
                //Node.Connect(rotor2.RotorPoints[3].LeftNode, rotor2.RotorPoints[2].RightNode);


                //machine.InsertRotor(reflector);
                //machine.InsertRotor(rotor1);
                //machine.InsertRotor(rotor2);
            }
            catch (Exception ex)
            {
                Assert.Fail("Could not create machine: {0}", ex.Message);
            }
        }
    }
}
