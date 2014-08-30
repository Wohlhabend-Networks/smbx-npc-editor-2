using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smbx_npc_editor
{
    public partial class SpinnerControlValue : UserControl
    {
        public SpinnerControlValue()
        {
            InitializeComponent();
        }

        public int GetSpinnerValue()
        {
            return (int)valueSpinner.Value;
        }

        public bool ControlsEnabled()
        {
            if (enabledCheckBox.Checked)
                return true;
            else
                return false;
        }

        #region WinForms Stuff
        private string _LabelText = String.Empty;
        [Description("The label's text")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LabelText
        {
            get { return _LabelText; }
            set{
                if(value == null)
                    value = String.Empty;
                if(!_LabelText.Equals(value, StringComparison.CurrentCulture))
                {
                    _LabelText = value;
                    UpdateLabelText();
                }
            }
        }

        private int _SpinnerVal = 0;
        [Description("Value of the spinner")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int SpinnerValue
        {
            get { return _SpinnerVal; }
            set
            {
                if (value == null)
                    value = 0;
                if (!_SpinnerVal.Equals(value))
                {
                    _SpinnerVal = value;
                    UpdateSpinnerVal();
                }
            }
        }

        private bool checkBoxEnabled = false;
        [Description("Whether or not the inner controls are enabled")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool CheckBoxEnabled
        {
            get { return checkBoxEnabled; }
            set
            {
                if (value == null)
                    value = false;
                if(!checkBoxEnabled.Equals(value))
                {
                    checkBoxEnabled = value;
                    UpdateControlsOnCheckbox();
                }
            }
        }

        private void UpdateControlsOnCheckbox()
        {
            if(checkBoxEnabled == true)
            {
                enabledCheckBox.Checked = true;
                valueSpinner.Enabled = true;
            }
            else if(checkBoxEnabled == false)
            {
                enabledCheckBox.Checked = false;
                valueSpinner.Enabled = false;
            }
        }

        private void UpdateSpinnerVal()
        {
            valueSpinner.Value = _SpinnerVal;
        }

        private void UpdateLabelText()
        {
            label.Text = _LabelText;
        }
        #endregion
    }
}
