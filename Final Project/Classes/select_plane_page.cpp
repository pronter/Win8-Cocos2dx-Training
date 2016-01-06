#include "select_plane_page.h"
#include "main_game.h"
 

SelectPlanePage* SelectPlanePage::create(int page)
{
	SelectPlanePage *pRet = new SelectPlanePage();
    if (pRet && pRet->initLevelPage(page))
    {
        pRet->autorelease();
        return pRet;
    }
    else
    {
        delete pRet;
        pRet = NULL;
        return NULL;
    }
}

bool SelectPlanePage::initLevelPage(int page)
{
    if (!Node::init())
    {
        return false;
    }

	page_ = page;
    auto size = Director::getInstance()->getWinSize();
   //����
	auto sprite =Sprite::create("ui/bg_select.png");
	sprite->setPosition(Point(size.width / 2, size.height / 2 ));
    addChild(sprite);
	sprite->setVisible(false);
    
	//���֡����
	auto animation = Animation::create();

	for (int i = 1; i <= 2; ++i)
	{
		auto spr_name = String::createWithFormat("plane/heros%d_%d.png", page,i);
		animation->addSpriteFrameWithFile(spr_name->getCString());
	}

	animation->setDelayPerUnit(0.2f);
	animation->setLoops(-1);

	auto spr_name = String::createWithFormat("plane/heros%d_%d.png", page, 1);
	auto plane_sprite = Sprite::create(spr_name->getCString());
	plane_sprite->setTag(page_);
	plane_sprite->setPosition(size.width / 2, size.height / 2);
	plane_sprite->setScale(2);
	this->addChild(plane_sprite);
	//����
	auto animate = Animate::create(animation);
	plane_sprite->runAction(animate);

/*	//���menu
	auto dictionary = Dictionary::createWithContentsOfFile("fonts/text.xml");
	auto btn_label = Label::create();
	btn_label->setString(((__String*)(dictionary->objectForKey("select")))->getCString());
	btn_label->setSystemFontSize(40);
	btn_label->setColor(ccc3(36,106,32));
	auto start_menu = MenuItemLabel::create(btn_label, CC_CALLBACK_1(SelectPlanePage::menuStartCallback, this));

	auto menu = Menu::create(start_menu, NULL);
	menu->setPosition(ccp(size.width / 2, size.height * 0.3));
	this->addChild(menu);
	*/

	auto listener1 = EventListenerTouchOneByOne::create();
	listener1->onTouchBegan = [=](Touch* touch, Event* event) {
		Size s = plane_sprite->getContentSize();
		Vec2 pos = plane_sprite->getPosition();
		Size cont = plane_sprite->getContentSize();
		Rect rect = Rect(pos.x - cont.width / 2, pos.y - cont.height/ 2, s.width, s.height);
		//log("sss %d\n", plane_sprite->getTag());

		if (rect.containsPoint(touch->getLocation()))
		{
			int x = rand() % 3 + 1;

			//menuStartCallback(this);
			start(x);
			return false;
		}
		return true;
	};
    
	Director::getInstance()->getEventDispatcher()->addEventListenerWithSceneGraphPriority(listener1, this);

    return true;
}

void SelectPlanePage::start(int page) {

	auto scene = Scene::create();
	auto main_layer = MainGame::create();
	//��ʼ����ҷɻ�
	main_layer->init_hero_plane(page);
	scene->addChild(main_layer);

	Director::getInstance()->replaceScene(TransitionFadeTR::create(1.0f, scene));

}


void SelectPlanePage::menuStartCallback(Ref* pSender)
{
	//������Ϸ����
	auto scene = Scene::create();
	auto main_layer = MainGame::create();
	//��ʼ����ҷɻ�
	main_layer->init_hero_plane(page_);
	scene->addChild(main_layer);
	
	Director::getInstance()->replaceScene(TransitionFadeTR::create(1.0f, scene));
}
