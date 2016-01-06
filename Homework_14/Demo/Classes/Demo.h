#pragma once

#include "cocos2d.h"

USING_NS_CC;

class Demo :public Layer
{
public:
	static Scene* createScene();
	static Demo* create(PhysicsWorld* world);
	bool init(PhysicsWorld* world);

	void testContact();
	bool onContactBegan(PhysicsContact& contact);
	void testContactFilter();

	void testPhysicsJointSpring();
	void testPhysicsJointDistance();

	void testParticleFireworks();
	void testParticleSnow();
	void testExternalParticle();
private:
	Demo();
	~Demo();

	PhysicsWorld* m_world;
	Sprite* m_basketball;
	Sprite* m_soccer;
};