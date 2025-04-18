﻿using System.Collections.Generic;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents an item in a combobox control within a form.
    /// </summary>
    public class ControlFormItemInputComboboxItem
    {
        private readonly List<ControlFormItemInputComboboxItem> _subItems = [];

        /// <summary>
        /// Returns the sub-items of the combobox item.
        /// </summary>
        public IEnumerable<ControlFormItemInputComboboxItem> SubItems => _subItems;

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Returns or sets a value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Returns or sets a tag value.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="subitems">The child entries.</param>
        public ControlFormItemInputComboboxItem(params ControlFormItemInputComboboxItem[] subitems)
        {
            _subItems.AddRange(subitems);
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="subitems">The child entries.</param>
        public ControlFormItemInputComboboxItem(IEnumerable<ControlFormItemInputComboboxItem> subitems)
            : this()
        {
            _subItems.AddRange(subitems);
        }
    }
}
