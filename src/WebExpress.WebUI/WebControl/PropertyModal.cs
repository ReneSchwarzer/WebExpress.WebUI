namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the characteristics of a modal.
    /// </summary>
    public class PropertyModal
    {
        /// <summary>
        /// Returns the modal type.
        /// </summary>
        public TypeModal Type { get; protected set; }

        /// <summary>
        /// Returns the custom modal.
        /// </summary>
        public ControlModal Modal { get; protected set; }

        /// <summary>
        /// Returns the size of the modal.
        /// </summary>
        public TypeModalSize Size { get; protected set; }

        /// <summary>
        /// Returns the uri.
        /// </summary>
        public string Uri { get; protected set; }

        /// <summary>
        /// Returns the forwarding uri.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PropertyModal()
        {
            Type = TypeModal.None;
            Size = TypeModalSize.Default;
            Modal = null;
            Uri = null;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="type">The modal type.</param>
        /// <param name="size">The size of the modal.</param>
        public PropertyModal(TypeModal type, TypeModalSize size = TypeModalSize.Default)
        {
            Type = type;
            Size = size;
            Modal = null;
            Uri = null;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="type">The modal type.</param>
        /// <param name="modal">Custom modal or null.</param>
        /// <param name="size">The size of the modal.</param>
        public PropertyModal(TypeModal type, ControlModal modal, TypeModalSize size = TypeModalSize.Default)
        {
            Type = type;
            Size = size;
            Modal = modal;
            Uri = null;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="type">The modal type.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="size">The size of the modal.</param>
        public PropertyModal(TypeModal type, string uri, TypeModalSize size = TypeModalSize.Default)
        {
            Type = type;
            Size = size;
            Modal = null;
            Uri = uri;
        }
    }
}
