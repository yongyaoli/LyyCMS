﻿var $url = '/cms/settings/settingsCreateRuleLayerSet';

var data = utils.init({
  siteId: utils.getQueryInt("siteId"),
  isChannel: utils.getQueryBoolean("isChannel"),
  channelId: utils.getQueryInt("channelId"),
  form: {
    rule: utils.getQueryString("rule")
  },
  dict: null
});

var methods = {
  apiConfig: function () {
    var $this = this;

    utils.loading(this, true);
    $api.get($url, {
      params: {
        siteId: this.siteId,
        isChannel: this.isChannel,
        channelId: this.channelId
      }
    }).then(function (response) {
      var res = response.data;

      $this.dict = res.value;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  copyToClipboard: function(text) {
    if (window.clipboardData && window.clipboardData.setData) {
      // Internet Explorer-specific code path to prevent textarea being shown while dialog is visible.
      return clipboardData.setData("Text", text);
    }
    else if (document.queryCommandSupported && document.queryCommandSupported("copy")) {
      var textarea = document.createElement("textarea");
      textarea.textContent = text;
      textarea.style.position = "fixed";  // Prevent scrolling to bottom of page in Microsoft Edge.
      document.body.appendChild(textarea);
      textarea.select();
      try {
        return document.execCommand("copy");  // Security exception may be thrown by some browsers.
      }
      catch (ex) {
        return false;
      }
      finally {
        document.body.removeChild(textarea);
      }
    }
  },

  btnCopyClick: function(text) {
    if (this.copyToClipboard(text)) {
      utils.success('文本复制成功!');
    }
  },

  btnSubmitClick: function() {
    var $this = this;
    this.$refs.form.validate(function(valid) {
      if (valid) {
        var $parent = parent.$vue;
        $parent.setRuleText($this.form.rule, $this.isChannel);
        utils.closeLayer();
      }
    });
  },

  btnCancelClick: function() {
    utils.closeLayer();
  }
};

var $vue = new Vue({
  el: '#main',
  data: data,
  methods: methods,
  created: function () {
    utils.keyPress(this.btnSubmitClick, this.btnCancelClick);
    this.apiConfig();
  }
});
