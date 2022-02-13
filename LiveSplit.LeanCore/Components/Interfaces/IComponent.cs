using System;
using System.Collections.Generic;
using System.Xml;

namespace LiveSplit.LeanCore.Components.Interfaces
{
    public interface IComponent : IDisposable
    {
        /// <summary>
        /// Returns the name of the component.
        /// </summary>
        string ComponentName { get; }


        /// <summary>
        /// Returns the XML serialization of the component's settings.
        /// </summary>
        /// <param name="document">The XML document.</param>
        /// <returns> Returns the XML serialization of the component's settings.</returns>
        XmlNode GetSettings(XmlDocument document);

        /// <summary>
        /// Sets the settings of the component based on the serialized version of the settings.
        /// </summary>
        /// <param name="settings">A serialized version of the settings that need to be set.</param>
        void SetSettings(XmlNode settings);
    }
}
