#ifndef __WIN_H__
#define __WIN_H__
#include "network/HttpClient.h"
#include <iostream>
#include <string>
#include "cocos2d.h"
using namespace cocos2d;
using namespace std;
using namespace cocos2d::network;

class Win : public cocos2d::Layer
{
public:
  // there's no 'id' in cpp, so we recommend returning the class instance pointer
  static cocos2d::Scene* createScene();

  // Here's a difference. Method 'init' in cocos2d-x returns bool, instead of returning 'id' in cocos2d-iphone
  virtual bool init();

  // a selector callback
  void menuCloseCallback(cocos2d::Ref* pSender);

  void menuCallback(cocos2d::Ref* pSender);
  //服务器响应完成后的操作函数
  void onHttpRequestCompleted(HttpClient *sender, HttpResponse *response);
  //将分数post给服务器
  void postData();
  //从服务器中get排行榜
  void getRank();
  CREATE_FUNC(Win);

  int type = 0;
  //排行榜分数
  vector<string> scores;
  //个人分数
  static int score;

};

#endif // __HELLOWORLD_SCENE_H__
