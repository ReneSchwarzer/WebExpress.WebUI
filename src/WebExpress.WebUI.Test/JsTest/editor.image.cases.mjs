/** Image regressions shared by the Node runner and browser page. */
export function imageCases(test, assert, loadEditor) {
    test("editing an image preserves its identity, link, attributes and document position", () => {
        const { wx, root, panels, editorMock } = loadEditor();
        root.innerHTML = '<p>before<a href="/article"><img src="/old.png" alt="old" class="photo" data-id="asset" style="width: 100px;"></a>after</p>';
        const image = root.querySelector("img");
        const anchor = image.parentNode;
        const editor = editorMock();
        editor._history = new wx.EditorHistory(editor);
        editor._syncValue = () => editor._history.notify(false);
        const modal = {
            _editor: editor, _imageTarget: image,
            _image: { webUrlInput: { value: "/new.png" }, webAltInput: { value: 'An "image" <caption>' },
                widthInput: { value: "50%" }, heightInput: { value: "" } },
            hide() { this.hidden = true; }
        };
        panels.get("image-web").onSubmit(modal);
        assert.equal(root.querySelector("img"), image);
        assert.equal(image.parentNode, anchor);
        assert.equal(image.getAttribute("class"), "photo");
        assert.equal(image.getAttribute("data-id"), "asset");
        assert.equal(image.getAttribute("src"), "/new.png");
        assert.equal(image.getAttribute("alt"), 'An "image" <caption>');
        assert.equal(image.style.width, "50%");
        assert.equal(root.textContent, "beforeafter");
        assert.equal(modal.hidden, true);
        editor._history.undo();
        assert.equal(root.querySelector("img").getAttribute("src"), "/old.png");
        editor._history.redo();
        assert.equal(root.querySelector("img").getAttribute("src"), "/new.png");
    });

    test("opening an image dialog keeps the image until submit and passes its dimensions", () => {
        const { root, plugins, editorMock } = loadEditor();
        root.innerHTML = '<p><img src="/old.png" alt="old" width="320" height="200"></p>';
        const image = root.querySelector("img");
        const plugin = plugins.get("media");
        plugin.getContextMenuItems(editorMock(), image)[0].action();
        const modal = plugin.imageModal.ctrl;
        assert.equal(root.querySelector("img"), image);
        assert.equal(modal._imageTarget, image);
        assert.equal(modal._imagePrefill.width, "320");
        assert.equal(modal._imagePrefill.height, "200");
        assert.equal(modal.page, "image-web");
        modal.hide?.();
        assert.equal(root.querySelector("img"), image);
    });

    test("image context actions resize, align and remove with undo", () => {
        const { wx, root, plugins, editorMock } = loadEditor();
        root.innerHTML = '<p>before<img src="/photo.png" width="320" height="200">after</p>';
        const image = root.querySelector("img");
        const editor = editorMock();
        editor._history = new wx.EditorHistory(editor);
        editor._syncValue = () => editor._history.notify(false);
        const items = plugins.get("media").getContextMenuItems(editor, image);
        items.find(item => item.label.endsWith("align.center")).action();
        assert.equal(image.style.marginLeft, "auto");
        assert.equal(image.style.marginRight, "auto");
        items.find(item => item.submenu).submenu[1].action();
        assert.equal(image.style.width, "50%");
        assert.equal(image.getAttribute("height"), null);
        items.find(item => item.label.endsWith("remove.image")).action();
        assert.equal(root.querySelector("img"), null);
        assert.equal(root.textContent, "beforeafter");
        editor._history.undo();
        assert.equal(root.querySelector("img").style.width, "50%");
    });

    test("image dimension validation rejects invalid CSS and accepts automatic sizing", () => {
        const { wx } = loadEditor();
        for (const value of ["-1", "0", "NaN", "url(test)", "1px;color:red"]) {
            assert.equal(wx.EditorImage.dimension(value), null);
        }
        assert.equal(wx.EditorImage.dimension("320"), "320px");
        assert.equal(wx.EditorImage.dimension("50%"), "50%");
        assert.equal(wx.EditorImage.dimension(""), "");
    });

    test("a stale image edit never inserts a duplicate at a different cursor position", () => {
        const { root, document, panels, editorMock } = loadEditor();
        root.innerHTML = '<p>unchanged</p>';
        const editor = editorMock();
        let inserted = false;
        editor.insertHtmlAtCursor = () => { inserted = true; };
        const modal = { _editor: editor, _imageTarget: document.createElement("img"),
            _image: { webUrlInput: { value: "/new.png" }, webAltInput: { value: "" } }, hide() {} };
        panels.get("image-web").onSubmit(modal);
        assert.equal(inserted, false);
        assert.equal(root.innerHTML, "<p>unchanged</p>");
    });

    test("choosing a site image updates the existing image without losing its size", () => {
        const { root, panels, editorMock } = loadEditor();
        root.innerHTML = '<p><img src="/old.png" width="320"></p>';
        const image = root.querySelector("img");
        const modal = { _editor: editorMock(), _imageTarget: image,
            _image: { selectedSiteImage: { src: "/site.png", alt: "Site" }, siteAltInput: { value: "New" } },
            hide() {} };
        panels.get("image-site").onSubmit(modal);
        assert.equal(root.querySelector("img"), image);
        assert.equal(image.getAttribute("width"), "320");
        assert.equal(image.getAttribute("src"), "/site.png");
        assert.equal(image.getAttribute("alt"), "New");
    });
}
