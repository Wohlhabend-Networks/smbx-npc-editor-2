using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace smbx_npc_editor
{
    public partial class ComboBoxControlValue : UserControl
    {
        bool _isReset = false;

        public ComboBoxControlValue()
        {
            InitializeComponent();
        }

        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enabledCheckBox.Checked == true)
                ComboValue.Enabled = true;
            else
                ComboValue.Enabled = false;
        }

        public bool isReset
        {
            get { return _isReset; }
            set { _isReset = value; }
        }

        public int GetSelectedIndex()
        {
            return ComboValue.SelectedIndex;
        }

        public void SetSelectedIndex(int i)
        {
            try
            {
                ComboValue.SelectedIndex = i;
            }
            catch
            {
                ComboValue.SelectedIndex = 0;
            }
        }

        public string GetSelectedItemText()
        {
            return ComboValue.SelectedText;
        }

        public bool ControlsEnabled()
        {
            if (enabledCheckBox.Checked == true)
                return true;
            else
                return false;
        }
        public void Reset()
        {
            enabledCheckBox.Checked = false;
            ComboValue.SelectedIndex = -1;
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
                if (!_valueTag.Equals(value, StringComparison.CurrentCulture))
                {
                    _valueTag = value;
                    UpdateComboBoxTag();
                }
            }
        }

        private void UpdateComboBoxTag()
        {
            ComboValue.Tag = _valueTag;
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
            set
            {
                if (value == null)
                    value = String.Empty;

                if(!_LabelText.Equals(value, StringComparison.CurrentCulture))
                {
                    _LabelText = value;
                    UpdateLabelText();
                }
            }
        }

        private ComboBox.ObjectCollection _obj;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection ComboBoxValues
        {
            get { return ComboValue.Items; }
            set
            {
                _obj = value;
                UpdateComboItems();
            }
        }

        private void UpdateComboItems()
        {
            ComboValue.Items.Clear();
            for (int i = 0; i == _obj.Count; i++ )
            {
                ComboValue.Items.Add(_obj[i].ToString());
            }
        }

        private void UpdateLabelText()
        {
            label.Text = _LabelText;
        }
        #endregion

        private void ComboBoxControlValue_Load(object sender, EventArgs e)
        {
            //ComboValue.SelectedIndex = 0;
        }
    }
}
