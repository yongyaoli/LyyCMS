﻿var $url = '/cms/templates/templatesReference';

var data = utils.init({
  siteId: utils.getQueryInt("siteId"),
  elements: null,
  elementPanel: false,
  elementTagName: '',
  elementTitle: '',
  elementFields: null
});

var methods = {
  apiList: function () {
    var $this = this;

    $api.get($url, {
      params: {
        siteId: this.siteId
      }
    }).then(function (response) {
      var res = response.data;

      $this.elements = res;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiFields: function (element) {
    this.elementTagName = element.name;
    this.elementTitle = element.title;
    var $this = this;

    utils.loading(this, true);
    $api.post($url, {
      siteId: this.siteId,
      elementName: element.elementName
    }).then(function (response) {
      var res = response.data;

      $this.elementPanel = true;
      $this.elementFields = res;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  getLinkUrl: function(name) {
    return cloud.getDocsUrl('stl/' + name + '/');
  },

  getFieldLinkUrl: function(field) {
    return cloud.getDocsUrl('stl/' + this.elementTagName + '/#' + field.name.toLowerCase() + '-' + field.title.toLowerCase());
  },

  btnElementSelectClick: function (element) {
    this.apiFields(element);
  },

  btnElementCancelClick: function () {
    this.elementPanel = false;
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
    utils.keyPress(null, this.btnCloseClick);
    this.apiList();
  }
});
