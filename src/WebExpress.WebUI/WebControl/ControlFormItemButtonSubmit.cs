//using WebExpress.WebCore.Internationalization;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlFormItemButtonSubmit : ControlFormItemButton
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The control id.</param>
//        public ControlFormItemButtonSubmit(string id)
//            : base(id)
//        {
//            Name = Id;
//            Text = I18N.Translate("webexpress.webui", "form.submit.label");
//            Icon = new PropertyIcon(TypeIcon.Save);
//            Color = new PropertyColorButton(TypeColorButton.Success);
//            Type = TypeButton.Submit;
//            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None);
//            OnClick = new PropertyOnClick($"$('#{Id}').val('submit');");
//        }
//    }
//}
