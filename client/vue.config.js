const webpack = require("webpack");

module.exports = {
  transpileDependencies: true,
  configureWebpack: {
    plugins: [
      new webpack.DefinePlugin({
        "process.env.VUE_APP_BASE_URL": JSON.stringify(
          process.env.VUE_APP_BASE_URL
        ),
      }),
    ],
  },
};
