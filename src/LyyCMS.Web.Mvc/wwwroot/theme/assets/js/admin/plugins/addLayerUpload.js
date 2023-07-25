﻿var $url = '/plugins/addLayerUpload';
var $urlActionsUpload = $url + '/actions/upload';
var $urlActionsOverride = $url + '/actions/override';
var $urlActionsRestart = $url + '/actions/restart';

var data = utils.init({
  uploadUrl: $apiUrl + $urlActionsUpload,
  uploadList: [],
  plugin: null
});

var methods = {
  apiOverride: function(fileName) {
    var $this = this;

    $this.apiRestart(true, function() {
      $api.post($urlActionsOverride, {
        pluginId: $this.plugin.pluginId,
        fileName: fileName
      }).then(function () {
        parent.utils.alertSuccess({
          title: '插件更新成功',
          text: '插件名称：' + $this.plugin.displayName + '，插件Id：' + $this.plugin.pluginId + '，插件版本：' + $this.plugin.version,
          callback: function() {
            $this.apiRestart(false, function() {
              window.top.location.reload(true);
            });
          }
        });
      }).catch(function (error) {
        utils.error(error);
      }).then(function () {
        utils.loading($this, false);
      });
    });
  },

  apiRestart: function (isDisablePlugins, callback) {
    utils.loading(this, true);
    $api.post($urlActionsRestart, {
      isDisablePlugins: isDisablePlugins
    }).then(function (response) {
      if (isDisablePlugins) {
        setTimeout(function () {
          callback();
        }, 120000);
      } else {
        setTimeout(function () {
          callback();
        }, 30000);
      }
    }).catch(function (error) {
      utils.error(error);
    });
  },

  uploadBefore(file) {
    var isZip = file.name.indexOf('.zip', file.name.length - '.zip'.length) !== -1;
    if (!isZip) {
      utils.error('插件包文件只能是 Zip 格式!');
    }
    return isZip;
  },

  uploadProgress: function() {
    utils.loading(this, true);
  },

  uploadSuccess: function(res, file) {
    var $this = this;

    this.loading && this.loading.close();

    var oldPlugin = res.oldPlugin;
    $this.plugin = res.newPlugin;
    var fileName = res.fileName;

    if (oldPlugin) {
      parent.utils.alertDelete({
        title: '是否覆盖插件',
        text: '系统检测到插件已存在，插件名称：' + $this.plugin.displayName + '，插件Id：' + $this.plugin.pluginId + '，当前版本：' + oldPlugin.version + '，上传包版本：' + $this.plugin.version + '，是否覆盖？',
        button: '覆盖插件',
        callback: function() {
          $this.apiOverride(fileName);
        }
      });
    } else {
      $this.apiRestart(false, function() {
        parent.utils.alertSuccess({
          title: '插件安装成功',
          text: '插件名称：' + $this.plugin.displayName + '，插件Id：' + $this.plugin.pluginId + '，插件版本：' + $this.plugin.version,
          callback: function() {
            window.top.location.reload(true);
          }
        });
      });
    }
  },

  uploadError: function(err) {
    this.loading && this.loading.close();
    var error = JSON.parse(err.message);
    utils.error(error.message);
  },

  btnCancelClick: function () {
    utils.closeLayer();
  }
};

var $vue = new Vue({
  el: '#main',
  data: data,
  methods: methods,
  created: function () {
    utils.keyPress(null, this.btnCancelClick);
    utils.loading(this, false);
  }
});
