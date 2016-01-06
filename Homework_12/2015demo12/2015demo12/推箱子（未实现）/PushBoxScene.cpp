#include "PushBox/PushBoxScene.h"


const float SIZE_WSAD = 100.0;
const int FONT_SIZE = 100;


PushBoxScene::PushBoxScene()
{

}

PushBoxScene::~PushBoxScene()
{

}

bool PushBoxScene::init()
{
	if (!Layer::init())
	{
		return false;
	}

	visibleSize = Director::getInstance()->getVisibleSize();

	initTouchEvent();

	return true;
}



void PushBoxScene::initTouchEvent(){
	auto menu = Menu::create();
	menu->setPosition(visibleSize.width,0);
	menu->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	this->addChild(menu,10);

	auto label_W = Label::createWithTTF("W", "fonts/Marker Felt.ttf", FONT_SIZE);
	auto label_S = Label::createWithTTF("S", "fonts/Marker Felt.ttf", FONT_SIZE);
	auto label_A = Label::createWithTTF("A", "fonts/Marker Felt.ttf", FONT_SIZE);
	auto label_D = Label::createWithTTF("D", "fonts/Marker Felt.ttf", FONT_SIZE);

	auto button_up = MenuItemLabel::create(label_W, CC_CALLBACK_1(PushBoxScene::onUpPressed, this));
	auto button_down = MenuItemLabel::create(label_S, CC_CALLBACK_1(PushBoxScene::onDownPressed, this));
	auto button_left = MenuItemLabel::create(label_A, CC_CALLBACK_1(PushBoxScene::onLeftPressed, this));
	auto button_right = MenuItemLabel::create(label_D, CC_CALLBACK_1(PushBoxScene::onRightPressed, this));
	
	button_up->setPosition(SIZE_WSAD * -1, SIZE_WSAD * 2);
	button_down->setPosition(SIZE_WSAD * -1, SIZE_WSAD * 0);
	button_left->setPosition(SIZE_WSAD * -2, SIZE_WSAD * 1);
	button_right->setPosition(SIZE_WSAD * 0, SIZE_WSAD * 1);

	button_up->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_down->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_left->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);
	button_right->setAnchorPoint(Vec2::ANCHOR_BOTTOM_RIGHT);

	menu->addChild(button_up);
	menu->addChild(button_down);
	menu->addChild(button_left);
	menu->addChild(button_right);
}







void PushBoxScene::onRightPressed(Ref* sender)
{
	//按下按键d的事件实现

}

void PushBoxScene::onLeftPressed(Ref* sender)
{
	//按下按键a的事件实现

}

void PushBoxScene::onUpPressed(Ref* sender)
{
	//按下按键w的事件实现

}

void PushBoxScene::onDownPressed(Ref* sender)
{
	//按下按键s的事件实现

}






