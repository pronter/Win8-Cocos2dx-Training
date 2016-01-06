#include "Demo.h"
using namespace std;


Demo::Demo()
	: m_world(NULL)
	, m_basketball(NULL)
	, m_soccer(NULL)
{

}

Demo::~Demo()
{
}

Scene* Demo::createScene()
{
	Scene* scene = Scene::createWithPhysics();
	scene->getPhysicsWorld()->setDebugDrawMask(PhysicsWorld::DEBUGDRAW_ALL);
	scene->getPhysicsWorld()->setGravity(Vec2::ZERO);
	auto layer = Demo::create(scene->getPhysicsWorld());
	scene->addChild(layer);

	return scene;
}

Demo* Demo::create(PhysicsWorld* world)  
{
	Demo* pRet = new Demo();
	if (pRet && pRet->init(world)) 
	{
		return pRet;
	}
	pRet = NULL;
	return NULL;
}

bool Demo::init(PhysicsWorld* world)
{
	if (!Layer::init())
	{
		return false;
	}
	m_world = world;

	Size winSize = Director::getInstance()->getWinSize();

	//边界
	Node* bound = Node::create();
	PhysicsBody* boundBody = PhysicsBody::createEdgeBox(winSize);
	boundBody->setDynamic(false);
	bound->setPhysicsBody(boundBody);
	bound->setPosition(winSize.width / 2, winSize.height / 2);
	addChild(bound);

	/*
		注意_contactTestBitmask的默认值为0x00000000，即任何碰撞都不检测
	*/
	m_basketball = Sprite::create("basketball.png");
	m_basketball->setPhysicsBody(PhysicsBody::createCircle(m_basketball->getContentSize().width / 2));
	m_basketball->getPhysicsBody()->setContactTestBitmask(0xFFFFFFFF);
	m_basketball->setPosition(300, 300);
	addChild(m_basketball);

	m_soccer = Sprite::create("soccer.png");
	m_soccer->setPhysicsBody(PhysicsBody::createCircle(m_soccer->getContentSize().width / 2));
	m_soccer->getPhysicsBody()->setContactTestBitmask(0xFFFFFFFF);
	m_soccer->setPosition(700, 300);
	addChild(m_soccer);

	testContact();
	//testContactFilter();

	//testPhysicsJointSpring();
	//testPhysicsJointDistance();
	
	//testParticleFireworks();
	//testParticleSnow();
	//testExternalParticle();
	return true;
}

/*
测试物理引擎碰撞检测的功能，当两个小球相撞时，将他们移除
*/
void Demo::testContact()
{
	m_basketball->getPhysicsBody()->setVelocity(Vec2(100, 0));
	m_soccer->getPhysicsBody()->setVelocity(Vec2(-100, 0));

	auto listener = EventListenerPhysicsContact::create();
	listener->onContactBegin = CC_CALLBACK_1(Demo::onContactBegan, this);
	Director::getInstance()->getEventDispatcher()
		->addEventListenerWithSceneGraphPriority(listener, this);
}

bool Demo::onContactBegan(PhysicsContact& contact)
{
	m_basketball->removeFromParentAndCleanup(true);
	m_soccer->removeFromParentAndCleanup(true);

	return true;
}

/*
	通过设置collisionBitmask使小球不产生碰撞效果
*/
void Demo::testContactFilter()
{
	m_basketball->getPhysicsBody()->setVelocity(Vec2(100, 0));
	m_soccer->getPhysicsBody()->setVelocity(Vec2(-100, 0));
	m_basketball->getPhysicsBody()->setCollisionBitmask(0x000000);

}

/*
*/
void Demo::testPhysicsJointSpring()
{
	m_basketball->getPhysicsBody()->setVelocity(Vec2(300, 0));
	m_soccer->getPhysicsBody()->setVelocity(Vec2(-300, 0));

	PhysicsJointSpring* springJoint = PhysicsJointSpring::construct(
		m_basketball->getPhysicsBody(), m_soccer->getPhysicsBody(),
		m_basketball->getAnchorPoint(), m_soccer->getAnchorPoint(),
		200, 0);
	m_world->addJoint(springJoint);
}

void Demo::testPhysicsJointDistance()
{
	m_basketball->getPhysicsBody()->setVelocity(Vec2(300, 0));

	PhysicsJointDistance* distanceJoint = PhysicsJointDistance::construct(
		m_basketball->getPhysicsBody(), m_soccer->getPhysicsBody(),
		Vec2::ZERO, Vec2::ZERO);
	m_world->addJoint(distanceJoint);
}

void Demo::testParticleFireworks()
{
	ParticleFireworks* fireworks = ParticleFireworks::create();
	fireworks->setPosition(500, 300);
	addChild(fireworks);
}

void Demo::testParticleSnow()
{
	ParticleSnow* snow = ParticleSnow::create();
	snow->setTexture(Director::getInstance()->getTextureCache()->addImage("snow.png"));
	snow->setPosition(500, 500);
	addChild(snow);
}

void Demo::testExternalParticle()
{
	auto paopao = ParticleSystemQuad::create("lizhi_qipao.plist");
	paopao->setPositionType(ParticleSystemQuad::PositionType::RELATIVE);
	paopao->setPosition(500, 300);
	paopao->setScale(2.0f);
	addChild(paopao);
}

