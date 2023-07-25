﻿var $url = '/cms/templates/templatesPreview';

var data = utils.init({
  siteId: utils.getQueryInt("siteId"),
  activeName: 'first',
  channels: null,
  form: {
    templateType: 'IndexPageTemplate',
    channelIds: [utils.getQueryInt("siteId")]
  },
  content: null,
  contentEditor: null,
  parsedContentEditor: null,
  parsedContent: ''
});

var methods = {
  apiConfig: function () {
    var $this = this;

    $api.get($url, {
      params: {
        siteId: this.siteId
      }
    }).then(function (response) {
      var res = response.data;

      $this.channels = res.channels;
      $this.content = res.content;

      setTimeout(function () {
        $('#content').height($(document).height() - 120);
        $('#parsedContent').height($(document).height() - 20);
        $('#preview').height($(document).height() - 20);

        require.config({ paths: { 'vs': utils.getAssetsUrl('lib/monaco-editor/min/vs') }});
        require(['vs/editor/editor.main'], function() {
            $this.contentEditor = monaco.editor.create(document.getElementById('content'), {
                value: $this.content,
                language: 'html'
            });
            $this.contentEditor.focus();
        });
      }, 100);
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiSubmit: function () {
    var $this = this;

    utils.loading(this, true);
    $api.post($url, {
      siteId: this.siteId,
      templateType: this.form.templateType,
      channelId: this.form.channelIds[this.form.channelIds.length - 1],
      content: this.content
    }).then(function (response) {
      var res = response.data;

      $this.parsedContent = res.value;

      $this.activeName = 'second';
      setTimeout(function () {
        require.config({ paths: { 'vs': utils.getAssetsUrl('lib/monaco-editor/min/vs') }});
        require(['vs/editor/editor.main'], function() {
            $this.parsedContentEditor = monaco.editor.create(document.getElementById('parsedContent'), {
                value: $this.parsedContent,
                language: 'html'
            });
            $this.parsedContentEditor.focus();
        });
      }, 100);
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  getEditorContent: function() {
    return this.contentEditor.getModel().getValue();
  },

  btnSubmitClick: function() {
    this.content = this.getEditorContent();
    if (!this.content) {
      utils.error('请输入需要解析的模板标签!');
      return;
    }

    this.apiSubmit();
  },

  btnCloseClick: function() {
    utils.removeTab();
  },
};

var $vue = new Vue({
  el: '#main',
  data: data,
  methods: methods,
  created: function () {
    utils.keyPress(this.btnSubmitClick, this.btnCloseClick);
    this.apiConfig();
  }
});
