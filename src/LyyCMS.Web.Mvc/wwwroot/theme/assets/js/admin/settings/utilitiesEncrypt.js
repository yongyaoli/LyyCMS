﻿var $url = '/settings/utilitiesEncrypt';

var data = utils.init({
  form: {
    isEncrypt: true,
    value: null,
  },
  results: null
});

var methods = {
  apiSubmit: function () {
    var $this = this;

    utils.loading(this, true);
    $api.post($url, {
      isEncrypt: this.form.isEncrypt,
      value: this.form.value
    }).then(function (response) {
      var res = response.data;

      $this.results = res.value;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  radioChanged: function() {
    this.results = '';
  },

  btnSubmitClick: function () {
    var $this = this;

    this.$refs.form.validate(function(valid) {
      if (valid) {
        $this.apiSubmit();
      }
    });
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
    utils.loading(this, false);
  }
});
