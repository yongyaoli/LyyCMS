﻿var $url = '/cms/templates/templatesIncludes';
var $urlDelete = $url + '/actions/delete';

var data = utils.init({
  siteId: utils.getQueryInt("siteId"),
  directories: null,
  allFiles: null,
  files: null,
  siteUrl: null,
  includeDir: null,
  directoryPaths: [],
  keyword: '',

  configPanel: false,
  configParent: null,
  configForm: null,
});

var methods = {
  apiGet: function () {
    var $this = this;

    utils.loading(this, true);
    $api.get($url, {
      params: {
        siteId: this.siteId,
      }
    }).then(function (response) {
      var res = response.data;

      $this.directories = res.directories;
      $this.allFiles = res.files;
      $this.siteUrl = res.siteUrl;
      $this.includeDir = res.includeDir;
      $this.reload();
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiDelete: function (file) {
    var $this = this;

    utils.loading(this, true);
    $api.post($urlDelete, {
      siteId: this.siteId,
      directoryPath: file.directoryPath,
      fileName: file.fileName
    }).then(function (response) {
      var res = response.data;

      $this.allFiles.splice($this.allFiles.indexOf(file), 1);
      $this.reload();
      utils.success('文件删除成功！');
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiConfig: function () {
    var $this = this;

    this.loading = this.$loading();
    $api.post($url + '/actions/config', this.configForm).then(function (response) {
      var res = response.data;

      $this.directories = res.directories;
      $this.allFiles = res.files;
      $this.siteUrl = res.siteUrl;
      $this.includeDir = res.includeDir;
      $this.reload();

      $this.configPanel = false;
      utils.success('文件夹路径设置成功!');
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  btnCopyClick: function(template) {
    var $this = this;

    utils.loading(this, true);
    $api.post($url + '/actions/copy', {
      siteId: this.siteId,
      templateId: template.id
    }).then(function (response) {
      var res = response.data;

      $this.directories = res.directories;
      $this.allFiles = res.files;
      $this.reload();
      utils.success('快速复制成功！');
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  btnDeleteClick: function (file) {
    var $this = this;

    utils.alertDelete({
      title: '删除文件',
      text: '此操作将删除文件 ' + file.directoryPath + '/' + file.fileName + '，确认吗？',
      callback: function () {
        $this.apiDelete(file);
      }
    });
  },

  btnAddClick: function() {
    utils.addTab('新增包含文件', this.getEditorUrl('', ''));
  },

  btnEditClick: function(file) {
    utils.addTab('编辑' + ':' + file.directoryPath + '/' + file.fileName, this.getEditorUrl(file.directoryPath, file.fileName));
  },

  getEditorUrl: function(directoryPath, fileName) {
    return utils.getCmsUrl('templatesAssetsEditor', {
      siteId: this.siteId,
      directoryPath: directoryPath,
      fileName: fileName,
      fileType: 'html',
      tabName: utils.getTabName()
    });
  },

  getPageUrl: function(directoryPath) {
    return this.siteUrl + '/' + directoryPath;
  },

  reload: function() {
    var $this = this;

    this.files = _.filter(this.allFiles, function(o) {
      var isDirectoryPath = true;
      var isKeyword = true;
      if ($this.directoryPaths.length > 0) {
        isDirectoryPath = false;
        for (var i = 0; i < $this.directoryPaths.length; i++) {
          var directoryPath = $this.directoryPaths[i][$this.directoryPaths[i].length - 1];
          if (o.directoryPath == directoryPath) {
            isDirectoryPath = true;
          }
        }
      }
      if ($this.keyword) {
        isKeyword = (o.directoryPath || '').indexOf($this.keyword) !== -1 || (o.fileName || '').indexOf($this.keyword) !== -1;
      }

      return isDirectoryPath && isKeyword;
    });
  },

  btnConfigClick: function() {
    this.configForm = {
      siteId: this.siteId,
      includeDir: this.includeDir,
    };
    this.configPanel = true;
  },

  btnConfigCancelClick: function() {
    this.configPanel = false;
  },

  btnConfigSubmitClick: function() {
    var $this = this;
    this.$refs.configForm.validate(function(valid) {
      if (valid) {
        $this.apiConfig();
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
    var $this = this;
    utils.keyPress(function() {
      if ($this.configPanel) {
        $this.btnConfigSubmitClick();
      }
    }, function() {
      if ($this.configPanel) {
        $this.btnConfigCancelClick();
      } else {
        $this.btnCloseClick();
      }
    });
    this.apiGet();
  }
});
