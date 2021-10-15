﻿
// Author: Dashie


using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Controls;
using DashFramework.DashResources;
using DashFramework.ControlTools;
using DashFramework.Data;


namespace DashFramework
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            private readonly Dictionary<Control, List<DashCheckBox>> Checkboxes = new Dictionary<Control, List<DashCheckBox>>();
            private readonly Dictionary<Control, List<Control>> Controls = new Dictionary<Control, List<Control>>();

            public readonly Dictionary<TextBox, int> TextBoxContainers = new Dictionary<TextBox, int>();

            readonly ResourceTools ResourceTool = new ResourceTools();
            readonly Transformer Transform = new Transformer();
            readonly DataTools DataTool = new DataTools();
        }
    }
}