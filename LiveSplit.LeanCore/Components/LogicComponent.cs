using LiveSplit.LeanCore.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LiveSplit.LeanCore.Components
{
    public abstract class LogicComponent : IComponent
    {
        public abstract string ComponentName
        {
            get;
        }


        public abstract XmlNode GetSettings(XmlDocument document);

        public abstract void SetSettings(System.Xml.XmlNode settings);

        public abstract void Dispose();
    }
}
