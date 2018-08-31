﻿/*
 *  "GEDKeeper", the personal genealogical database editor.
 *  Copyright (C) 2009-2018 by Sergey V. Zhdanovskih.
 *
 *  This file is part of "GEDKeeper".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Windows.Forms;
using BSLib;
using GKCore.Controllers;
using GKUI.Components;

namespace GKUI.Controllers
{
    public sealed class CheckBoxHandler : ControlHandler<CheckBox, CheckBoxHandler>, ICheckBoxHandler
    {
        public CheckBoxHandler(CheckBox control) : base(control)
        {
        }

        public bool Checked
        {
            get { return Control.Checked; }
            set { Control.Checked = value; }
        }

        public bool Enabled
        {
            get { return Control.Enabled; }
            set { Control.Enabled = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }
    }

    public sealed class ComboBoxHandler : ControlHandler<ComboBox, ComboBoxHandler>, IComboBoxHandler
    {
        public ComboBoxHandler(ComboBox control) : base(control)
        {
        }

        public bool Enabled
        {
            get { return Control.Enabled; }
            set { Control.Enabled = value; }
        }

        public bool ReadOnly
        {
            get { return (Control.DropDownStyle == ComboBoxStyle.DropDownList); }
            set { Control.DropDownStyle = (value) ? ComboBoxStyle.DropDownList : ComboBoxStyle.DropDown; }
        }

        public int SelectedIndex
        {
            get { return Control.SelectedIndex; }
            set { Control.SelectedIndex = value; }
        }

        public object SelectedItem
        {
            get { return Control.SelectedItem; }
            set { Control.SelectedItem = value; }
        }

        public object SelectedTag
        {
            get {
                return ((GKComboItem)Control.SelectedItem).Tag;
            }
            set {
                var ctl = Control;
                foreach (object item in ctl.Items) {
                    GKComboItem comboItem = (GKComboItem)item;
                    if (comboItem.Tag == value) {
                        ctl.SelectedItem = item;
                        return;
                    }
                }
                ctl.SelectedIndex = 0;
            }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }

        public void Add(object item)
        {
            Control.Items.Add(item);
        }

        public void AddRange(object[] items, bool sorted = false)
        {
            Control.Sorted = false;
            Control.Items.AddRange(items);
            Control.Sorted = sorted;
        }

        public void AddStrings(StringList strings)
        {
            int num = strings.Count;
            for (int i = 0; i < num; i++) {
                Control.Items.Add(strings[i]);
            }
        }

        public void Clear()
        {
            Control.Items.Clear();
        }
    }

    public sealed class TextBoxHandler : ControlHandler<TextBox, TextBoxHandler>, ITextBoxHandler
    {
        public TextBoxHandler(TextBox control) : base(control)
        {
        }

        public bool Enabled
        {
            get { return Control.Enabled; }
            set { Control.Enabled = value; }
        }

        public string[] Lines
        {
            get { return Control.Lines; }
            set { Control.Lines = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }
    }

    public sealed class MaskedTextBoxHandler : ControlHandler<MaskedTextBox, MaskedTextBoxHandler>, ITextBoxHandler
    {
        public MaskedTextBoxHandler(MaskedTextBox control) : base(control)
        {
        }

        public bool Enabled
        {
            get { return Control.Enabled; }
            set { Control.Enabled = value; }
        }

        public string[] Lines
        {
            get { return Control.Lines; }
            set { Control.Lines = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }
    }
}