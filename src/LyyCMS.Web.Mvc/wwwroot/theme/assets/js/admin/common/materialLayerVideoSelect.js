﻿var $url = '/common/material/layerVideoSelect';

var data = utils.init({
  siteId: utils.getQueryInt('siteId'),
  inputType: utils.getQueryString('inputType'),
  attributeName: utils.getQueryString('attributeName'),
  no: utils.getQueryInt('no'),

  groups: null,
  count: null,
  items: null,
  isCloudVod: null,
  urlList: null,
  renameId: 0,
  renameTitle: '',
  deleteId: 0,
  selectedGroupId: 0,

  form: {
    keyword: '',
    groupId: 0,
    page: 1,
    perPage: 24
  },
});

var methods = {
  insert: function(fileUrl) {
    if (this.inputType === 'Video') {
      if (parent.$vue.runMaterialLayerVideoSelect) {
        parent.$vue.runMaterialLayerVideoSelect(this.attributeName, this.no, fileUrl);
      }
    } else if (this.inputType === 'TextEditor') {
      parent.$vue.insertEditor(this.attributeName, '<img src="/sitefiles/assets/images/video-clip.png" style="width: 333px; height: 333px" playUrl="' + fileUrl + '" class="siteserver-stl-player" /><br/>');
    }
  },

  apiList: function (page) {
    var $this = this;
    this.form.page = page;

    utils.loading(this, true);
    $api.get($url, {
      params: this.form
    }).then(function (response) {
      var res = response.data;

      if (res.isCloudVod) {
        location.href = utils.getCloudsUrl('layerVodSelect', {
          inputType: $this.inputType,
          attributeName: $this.attributeName,
          no: $this.no,
        });
      }

      $this.groups = res.groups;
      $this.count = res.count;
      $this.items = res.items;
      $this.urlList = _.map($this.items, function (item) {
        return item.fileUrl;
      });
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  getGroupName: function() {
    var $this = this;
    if (this.form.groupId > 0) {
      var group = _.find(this.groups, function(o) { return o.id === $this.form.groupId; });
      return group.groupName;
    }
    return '';
  },

  btnSelectClick: function(material) {
    var $this = this;

    utils.loading(this, true);
    $api.post($url + '/actions/select', {
      siteId: this.siteId,
      materialId: material.id
    })
    .then(function(response) {
      var res = response.data;

      $this.insert(res.value);
      utils.closeLayer();
    })
    .catch(function(error) {
      utils.error(error);
    })
    .then(function() {
      utils.loading($this, false);
    });
  },

  btnSelectGroupClick: function (groupId) {
    this.selectedGroupId = (this.selectedGroupId === groupId) ? 0 :groupId;
  },

  btnGroupClick: function(groupId) {
    var $this = this;

    this.form.groupId = groupId;
    this.form.page = 1;

    utils.loading(this, true);
    $api.get($url, {
      params: this.form
    }).then(function (response) {
      var res = response.data;

      $this.groups = res.groups;
      $this.count = res.count;
      $this.items = res.items;
      $this.urlList = _.map($this.items, function (item) {
        return item.fileUrl;
      });
    }).catch(function (error) {
      $this.$notify.error({
          title: '错误',
          message: error.message
        });
    }).then(function () {
      utils.loading($this, false);
    });
  },

  btnSearchClick() {
    utils.loading(this, true);
    this.apiList(1);
  },

  btnPageClick: function(val) {
    utils.loading(this, true);
    this.apiList(val);
  },

  btnCancelClick: function () {
    utils.closeLayer();
  },
};

var $vue = new Vue({
  el: '#main',
  data: data,
  methods: methods,
  created: function () {
    utils.keyPress(null, this.btnCancelClick);
    this.apiList(1);
  }
});
