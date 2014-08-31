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
    public partial class CheckBoxValue : UserControl
    {
        public CheckBoxValue()
        {
            InitializeComponent();
        }

        public int GetCheckValue()
        {
            if (checkValue.Checked == true)
                return 1;
            else
                return 0;
        }

        #region WinForms Values
        private string _LabelText = String.Empty;
        [Description("The label's text")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LabelText
        {
            get { return _LabelText; }
            set
            {
                if (value == null)
                    value = String.Empty;

                if (!_LabelText.Equals(value, StringComparison.CurrentCulture))
                {
                    _LabelText = value;
                    UpdateLabelText();
                }
            }
        }

        [Description("Whether or not the 1 or 0 checkbox is checked")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        private bool _checked = false;
        public bool ValueChecked
        {
            get { return checkValue.Checked; }
            set
            {
                _checked = value;
                UpdateValue();
            }
        }
        private void UpdateLabelText()
        {
            label.Text = _LabelText;
        }

        private void UpdateControlsEnabled()
        {
            if (enabledCheckBox.Checked == true)
                checkValue.Enabled = true;
            else
                checkValue.Enabled = false;
        }
        private void UpdateValue()
        {
            if (_checked)
                checkValue.Checked = true;
            else
                checkValue.Checked = false;
        }
        private void UpdateValueText()
        {
            
        }
        #endregion

        private void checkValue_CheckedChanged(object sender, EventArgs e)
        {
            UpdateValueText();
        }

        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enabledCheckBox.Checked)
                checkValue.Enabled = true;
            else
                checkValue.Enabled = false;
        }
    }
}
