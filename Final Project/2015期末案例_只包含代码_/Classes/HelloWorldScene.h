#ifndef __HELLOWORLD_SCENE_H__
#define __HELLOWORLD_SCENE_H__

#include "cocos2d.h"
using namespace cocos2d;
class HelloWorld : public cocos2d::Layer
{
public:
    //创建层
    static cocos2d::Scene* createScene();

    //初始化菜单页
    virtual bool init();
    
    // 退出按钮回调函数
    void menuCloseCallback(cocos2d::Ref* pSender);

    //菜单按钮回调函数
    void menuCallback(Ref* sender);


    //触摸开始
    bool touchBegan(Touch* touch, Event* event_);
    //触摸过程 
    void touchMoved(Touch* touch, Event* event_);
    //触摸结束
    void touchEnded(Touch* touch, Event* event_);

    // implement the "static create()" method manually
    CREATE_FUNC(HelloWorld);
};

#endif // __HELLOWORLD_SCENE_H__
