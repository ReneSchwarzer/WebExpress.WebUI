using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public abstract class Control : IControl
    {
        /// <summary>
        /// Returns or sets the horizontal alignment.
        /// </summary>
        public virtual TypeHorizontalAlignment HorizontalAlignment
        {
            get => (TypeHorizontalAlignment)GetProperty(TypeHorizontalAlignment.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the text color.
        /// </summary>
        public virtual PropertyColorText TextColor
        {
            get => (PropertyColorText)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Returns or sets the background color.
        /// </summary>
        public virtual PropertyColorBackground BackgroundColor
        {
            get => (PropertyColorBackground)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Returns or sets the border color.
        /// </summary>
        public virtual PropertyColorBorder BorderColor
        {
            get => (PropertyColorBorder)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Returns or sets the padding.
        /// </summary>
        public virtual PropertySpacingPadding Padding
        {
            get => (PropertySpacingPadding)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass());
        }

        /// <summary>
        /// Returns or sets the margin.
        /// </summary>
        public virtual PropertySpacingMargin Margin
        {
            get => (PropertySpacingMargin)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass());
        }

        /// <summary>
        /// Returns or sets the border.
        /// </summary>
        public virtual PropertyBorder Border
        {
            get => (PropertyBorder)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass());
        }

        /// <summary>
        /// Returns or sets the column property if the control is on a grid.
        /// </summary>
        public virtual PropertyGrid GridColumn
        {
            get => (PropertyGrid)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass());
        }

        /// <summary>
        /// Returns or sets the width property of the control.
        /// </summary>
        public virtual TypeWidth Width
        {
            get => (TypeWidth)GetProperty(TypeWidth.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the height property of the control.
        /// </summary>
        public virtual TypeHeight Height
        {
            get => (TypeHeight)GetProperty(TypeHeight.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the id of the control.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Returns or sets the css class.
        /// </summary>
        public List<string> Classes { get; set; } = new List<string>();

        /// <summary>
        /// Retruns or sets properties determined by enums.
        /// </summary>
        protected Dictionary<string, Tuple<object, Func<string>, Func<string>>> Propertys { get; private set; } = new Dictionary<string, Tuple<object, Func<string>, Func<string>>>();

        /// <summary>
        /// Returns or sets the css style.
        /// </summary>
        public List<string> Styles { get; set; } = new List<string>();

        /// <summary>
        /// Returns or sets the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Returns or sets the OnClick attribute, which executes a java script on the client.
        /// </summary>
        public PropertyOnClick OnClick { get; set; }

        /// <summary>
        /// Determines whether the control is active and rendering.
        /// </summary>
        public bool Enable { get; set; } = true;

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public abstract IHtmlNode Render(RenderContext context);

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id.</param>
        public Control(string id = null)
        {
            Id = id;

            HorizontalAlignment = TypeHorizontalAlignment.Default;
            BackgroundColor = new PropertyColorBackground(TypeColorBackground.Default);
            Padding = new PropertySpacingPadding(PropertySpacing.Space.None);
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None);
        }

        /// <summary>
        /// Returns a property.
        /// </summary>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value.</returns>
        protected Enum GetProperty(Enum defaultValue, [CallerMemberName] string propertyName = "")
        {
            if (Propertys.ContainsKey(propertyName))
            {
                var item = Propertys[propertyName];

                return (Enum)item.Item1;
            }

            return defaultValue;
        }

        /// <summary>
        /// Returns a property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value.</returns>
        protected Enum GetProperty([CallerMemberName] string propertyName = "")
        {
            if (Propertys.ContainsKey(propertyName))
            {
                var item = Propertys[propertyName];

                return (Enum)item.Item1;
            }

            return null;
        }

        /// <summary>
        /// Returns a property.
        /// </summary>
        /// <param name="propertyName">he name of the property.</param>
        /// <returns>The value.</returns>
        protected IProperty GetPropertyObject([CallerMemberName] string propertyName = "")
        {
            if (Propertys.ContainsKey(propertyName))
            {
                var item = Propertys[propertyName];

                return (IProperty)item.Item1;
            }

            return null;
        }

        /// <summary>
        /// Returns a property value.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value.</returns>
        protected string GetPropertyValue([CallerMemberName] string propertyName = "")
        {
            if (Propertys.ContainsKey(propertyName))
            {
                var item = Propertys[propertyName];

                return item.Item2();
            }

            return null;
        }

        /// <summary>
        /// Stores a property.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="callbackClass">The callback function to determine the css class.</param>
        /// <param name="callbackStyle">The callback function to determine the css style.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected void SetProperty(Enum value, Func<string> callbackClass, Func<string> callbackStyle = null, [CallerMemberName] string propertyName = "")
        {
            if (!Propertys.ContainsKey(propertyName))
            {
                Propertys.Add(propertyName, new Tuple<object, Func<string>, Func<string>>(value, callbackClass, callbackStyle));
                return;
            }

            Propertys[propertyName] = new Tuple<object, Func<string>, Func<string>>(value, callbackClass, callbackStyle);
        }

        /// <summary>
        /// Stores a property.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="callbackClass">The callback function to determine the css class.</param>
        /// <param name="callbackStyle">The callback function to determine the css style.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected void SetProperty(IProperty value, Func<string> callbackClass, Func<string> callbackStyle = null, [CallerMemberName] string propertyName = "")
        {
            if (!Propertys.ContainsKey(propertyName))
            {
                Propertys.Add(propertyName, new Tuple<object, Func<string>, Func<string>>(value, callbackClass, callbackStyle));
                return;
            }

            Propertys[propertyName] = new Tuple<object, Func<string>, Func<string>>(value, callbackClass, callbackStyle);
        }

        /// <summary>
        /// Stores a property.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="callbackClass">The callback function to determine the css class.</param>
        /// <param name="callbackStyle">The callback function to determine the css style.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected void SetProperty(Func<string> callbackClass, Func<string> callbackStyle = null, [CallerMemberName] string propertyName = "")
        {
            if (!Propertys.ContainsKey(propertyName))
            {
                Propertys.Add(propertyName, new Tuple<object, Func<string>, Func<string>>(null, callbackClass, callbackStyle));
                return;
            }

            Propertys[propertyName] = new Tuple<object, Func<string>, Func<string>>(null, callbackClass, callbackStyle);
        }

        /// <summary>
        /// Returns all css classes.
        /// </summary>
        /// <returns>The css classes.</returns>
        protected string GetClasses()
        {
            var list = Propertys.Values.Select(x => x.Item2()).Where(x => !string.IsNullOrEmpty(x)).Distinct();

            return string.Join(" ", Classes.Union(list));
        }

        /// <summary>
        /// Returns all css styles.
        /// </summary>
        /// <returns>The css styles.</returns>
        protected string GetStyles()
        {
            var list = Propertys.Values.Where(x => x.Item3 != null).Select(x => x.Item3()).Where(x => !string.IsNullOrEmpty(x)).Distinct();

            return string.Join(" ", Styles.Union(list));
        }
    }
}
