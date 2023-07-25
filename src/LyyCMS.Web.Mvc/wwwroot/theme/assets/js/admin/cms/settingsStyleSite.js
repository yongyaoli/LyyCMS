﻿var $url = '/cms/settings/settingsStyleSite';
var $urlDelete = $url + '/actions/delete';
var $urlImport = $url + '/actions/import';

var data = utils.init({
  siteId: utils.getQueryInt('siteId'),
  returnUrl: utils.getQueryString('returnUrl'),
  urlUpload: null,
  inputTypes: null,
  tableName: null,
  relatedIdentities: null,
  styles: null,

  uploadPanel: false,
  uploadLoading: false,
  uploadList: []
});

var methods = {
  runTableStyleLayerAddMultiple: function() {
    this.apiGet();
  },

  runTableStyleLayerEditor: function() {
    this.apiGet();
  },

  runTableStyleLayerValidate: function() {
    this.apiGet();
  },

  apiGet: function () {
    var $this = this;

    utils.loading(this, true);
    $api.get($url, {
      params: {
        siteId: this.siteId
      }
    }).then(function (response) {
      var res = response.data;

      $this.inputTypes = res.inputTypes;
      $this.tableName = res.tableName;
      $this.relatedIdentities = res.relatedIdentities;
      $this.styles = res.styles;

      $this.urlUpload = $apiUrl + $urlImport + '?siteId=' + $this.siteId;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiDelete: function (attributeName) {
    var $this = this;

    utils.loading(this, true);
    $api.post($urlDelete, {
      siteId: this.siteId,
      attributeName: attributeName
    }).then(function (response) {
      var res = response.data;

      $this.styles = res.styles;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  getInputType: function (inputType) {
    var val = this.inputTypes.find(function (x) {
      return x.value === inputType;
    });
    return val ? val.label : '文本输入框';
  },

  getRules: function(rules) {
    if (!rules || rules.length === 0) return '无验证';
    return _.map(rules, function (rule) {
      return rule.message;
    }).join(',');
  },

  btnEditClick: function (attributeName) {
    utils.openLayer({
      title: '编辑字段',
      url: utils.getCommonUrl('tableStyleLayerEditor', {
        siteId: this.siteId,
        tableName: this.tableName,
        relatedIdentities: this.relatedIdentities,
        attributeName: attributeName
      })
    });
  },

  btnValidateClick: function (attributeName) {
    utils.openLayer({
      title: '设置验证规则',
      url: utils.getCommonUrl('tableStyleLayerValidate', {
        tableName: this.tableName,
        relatedIdentities: this.relatedIdentities,
        attributeName: attributeName
      })
    });
  },

  btnDeleteClick: function (attributeName) {
    var $this = this;

    utils.alertDelete({
      title: '删除字段',
      text: '此操作将删除字段 ' + attributeName + '，确定吗？',
      callback: function () {
        $this.apiDelete(attributeName);
      }
    });
  },

  btnAddClick: function () {
    utils.openLayer({
      title: '新增字段',
      url: utils.getCommonUrl('tableStyleLayerEditor', {
        siteId: this.siteId,
        tableName: this.tableName,
        relatedIdentities: this.relatedIdentities
      })
    });
  },

  btnAddMultipleClick: function () {
    utils.openLayer({
      title: '批量新增字段',
      url: utils.getCommonUrl('tableStyleLayerAddMultiple', {
        tableName: this.tableName,
        relatedIdentities: this.relatedIdentities
      })
    });
  },

  btnImportClick: function() {
    this.uploadPanel = true;
  },

  btnReturnClick: function () {
    location.href = this.returnUrl;
  },

  uploadBefore(file) {
    var isZip = file.name.indexOf('.zip', file.name.length - '.zip'.length) !== -1;
    if (!isZip) {
      utils.error('样式导入文件只能是 Zip 格式!');
    }
    return isZip;
  },

  uploadProgress: function() {
    utils.loading(this, true);
  },

  uploadSuccess: function(res, file) {
    this.uploadList = [];
    this.uploadPanel = false;
    utils.success('字段导入成功！');
    this.apiGet();
  },

  uploadError: function(err) {
    this.uploadList = [];
    utils.loading(this, false);
    var error = JSON.parse(err.message);
    utils.error(error.message);
  },

  btnExportClick: function() {
    var $this = this;

    utils.loading(this, true);
    $api.post($url + '/actions/export', {
      siteId: this.siteId
    }).then(function (response) {
      var res = response.data;

      window.open(res.value);
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
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
    var $this = this;
    utils.keyPress(null, function() {
      if ($this.uploadPanel) {
        $this.uploadPanel = false;
      } else {
        $this.btnCloseClick();
      }
    });
    this.apiGet();
  }
});
