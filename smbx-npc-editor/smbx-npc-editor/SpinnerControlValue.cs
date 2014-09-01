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
        public void Reset()
        {
            enabledCheckBox.Checked = false;
            valueSpinner.Value = valueSpinner.Minimum;
        }

        #region WinForms Stuff
        private string _valueTag = String.Empty;
        [Description("The tag of the value, for the SMBX NPC Editor this is used to identify which code it'll be assigned to")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ValueTag
        {
            get { return _valueTag; }
            set
            {
                if (value == null)
                    value = String.Empty;
                if(!_valueTag.Equals(value, StringComparison.CurrentCulture))
                {
                    _valueTag = value;
                    UpdateSpinnerTag();
                }
            }
        }

        private void UpdateSpinnerTag()
        {
            valueSpinner.Tag = _valueTag;
            enabledCheckBox.Tag = _valueTag;
        }

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
        private int _minValue = 0;
        [Description("The minimum value of the NumericUpDown")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int MinimumValue
        {
            get { return _minValue; }
            set
            {
                if (value == null)
                    value = 0;
                _minValue = value;
                UpdateValueSpinnerMin();
            }
        }

        private int _defValue = 0;
        [Description("The current value of the spinner.")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int CurrentValue
        {
            get { return _defValue; }
            set
            {
                if (value == null)
                    value = 0;
                _defValue = value;
                UpdateValueSpinnerDef();
            }
        }

        private int _maxValue = 666666;
        [Description("The current value of the spinner.")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public int MaximumValue
        {
            get { return _maxValue; }
            set
            {
                if (value == null)
                    value = 0;
                _maxValue = value;
                UpdateValueSpinnerMax();
            }
        }

        private void UpdateValueSpinnerMax()
        {
            valueSpinner.Maximum = (decimal)_maxValue;
        }

        private void UpdateValueSpinnerDef()
        {
            valueSpinner.Value = _defValue;
        }

        private void UpdateValueSpinnerMin()
        {
            valueSpinner.Minimum = _minValue;
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

        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(enabledCheckBox.Checked == true)
            {
                enabledCheckBox.Checked = true;
                valueSpinner.Enabled = true;
            }
            else
            {
                enabledCheckBox.Checked = false;
                valueSpinner.Enabled = false;
            }
        }

        private void SpinnerControlValue_Load(object sender, EventArgs e)
        {

        }
    }
}
