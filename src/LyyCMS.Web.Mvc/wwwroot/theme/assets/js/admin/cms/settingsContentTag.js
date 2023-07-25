﻿var $url = '/cms/settings/settingsContentTag';
var $urlDelete = $url + '/actions/delete';

var data = utils.init({
  siteId: utils.getQueryInt("siteId"),
  page: 1,
  perPage: PER_PAGE,
  total: null,
  tagNames: null,

  panel: false,
  form: null
});

var methods = {
  apiList: function (message) {
    var $this = this;

    utils.loading(this, true);
    $api.get($url, {
      params: {
        siteId: this.siteId,
        page: this.page,
        perPage: this.perPage
      }
    }).then(function (response) {
      var res = response.data;

      $this.total = res.total;
      $this.tagNames = res.tagNames;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
      if (message) {
        utils.success(message);
      }
    });
  },

  apiDelete: function (tagName) {
    var $this = this;

    utils.loading(this, true);
    $api.post($urlDelete, {
      siteId: this.siteId,
      page: this.page,
      perPage: this.perPage,
      tagName: tagName
    }).then(function (response) {
      var res = response.data;

      $this.apiList('内容标签删除成功！');
    }).catch(function (error) {
      utils.loading($this, false);
      utils.error(error);
    });
  },

  apiSubmit: function () {
    var $this = this;

    utils.loading(this, true);
    $api.post($url, this.form).then(function (response) {
      var res = response.data;

      $this.apiList('内容标签添加成功！');
      $this.panel = false;
    }).catch(function (error) {
      utils.loading($this, false);
      utils.error(error);
    });
  },

  btnAddClick: function () {
    this.panel = true;
    this.form = {
      siteId: this.siteId,
      tagNames: []
    };
  },

  btnDeleteClick: function (tagName) {
    var $this = this;

    utils.alertDelete({
      title: '删除内容标签',
      text: '此操作将删除内容标签 ' + tagName + '，确定吗？',
      callback: function () {
        $this.apiDelete(tagName);
      }
    });
  },

  btnSubmitClick: function () {
    var $this = this;
    this.$refs.form.validate(function(valid) {
      if (valid) {
        $this.apiSubmit();
      }
    });
  },

  btnCancelClick: function () {
    this.panel = false;
  },

  handleSizeChange: function(val) {
    this.perPage = val;
    this.apiList();
  },

  handleCurrentChange: function(val) {
    this.page = val;
    this.apiList();
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
    utils.keyPress(function () {
      if ($this.panel) {
        $this.btnSubmitClick();
      }
    }, function() {
      if ($this.panel) {
        $this.btnCancelClick();
      } else {
        $this.btnCloseClick();
      }
    });
    this.apiList();
  }
});
