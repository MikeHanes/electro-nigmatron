using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enigma.INTERFACES;
using System.Collections.Generic;

namespace Enigma.TESTS
{
    [TestClass]
    public class NodeFixtures
    {
        INode node1;
        INode node2;
        INode node3;

        [TestInitialize]
        public void Setup()
        {
            node1 = new Node(null);
            node2 = new Node(null);
            node3 = new Node(null);

            Node.Connect(node1, node2);
            Node.Connect(node1, node3);
           
        }

        [TestMethod]
        public void Node_Can_Electrify_All_Connected_Nodes()
        {
            List<INode> electrifiedNodes = new List<INode>();

            node1.Electrified += (source, args) =>
            {
                electrifiedNodes.Add((INode)source);
            };

            node2.Electrified += (source, args) => 
            {
                electrifiedNodes.Add((INode)source);
            };

            node3.Electrified += (source, args) =>
            {
                electrifiedNodes.Add((INode)source);
            };

            node1.Electrify();

            Assert.IsTrue(electrifiedNodes.Contains(node2));
            Assert.IsTrue(electrifiedNodes.Contains(node3));
        }



        [TestMethod]
        public void Electricity_Can_Flow_Down_Node_Chain()
        {

            List<INode> fireOrder = new List<INode>();

            node1.Electrified += (source, args) =>
            {
                fireOrder.Add((INode)source);
            };

            node2.Electrified += (source, args) =>
            {
                fireOrder.Add((INode)source);
            };

            node3.Electrified += (source, args) =>
            {
                fireOrder.Add((INode)source);
            };

            node2.Electrify();

            Assert.AreEqual(fireOrder[0], node1);
            Assert.AreEqual(fireOrder[1], node3);

        }

        [TestMethod]
        public void Calling_Node_Doesnt_Get_Electrified()
        {
            List<INode> electrifiedNodes = new List<INode>();

            node1.Electrified += (source, args) =>
            {
                electrifiedNodes.Add((INode)source);
            };

            node2.Electrified += (source, args) =>
            {
                electrifiedNodes.Add((INode)source);
            };

            node3.Electrified += (source, args) =>
            {
                electrifiedNodes.Add((INode)source);
            };

            node1.ElectrifyFrom(node2);


            Assert.IsFalse(electrifiedNodes.Contains(node2));

        }



      
    }
}
