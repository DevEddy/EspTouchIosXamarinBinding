﻿using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using CoreGraphics;

namespace EspTouchStatic
{
	// @interface ESPTouchResult : NSObject
	[BaseType(typeof(NSObject))]
	interface ESPTouchResult
	{
		// @property (assign, nonatomic) BOOL isSuc;
		[Export("isSuc")]
		bool IsSuc { get; set; }

		// @property (nonatomic, strong) NSString * bssid;
		[Export("bssid", ArgumentSemantic.Strong)]
		string Bssid { get; set; }

		// @property (assign, atomic) BOOL isCancelled;
		[Export("isCancelled")]
		bool IsCancelled { get; set; }

		// @property (atomic) NSData * ipAddrData;
		[Export("ipAddrData", ArgumentSemantic.Assign)]
		NSData IpAddrData { get; set; }

		// -(id)initWithIsSuc:(BOOL)isSuc andBssid:(NSString *)bssid andInetAddrData:(NSData *)ipAddrData;
		[Export("initWithIsSuc:andBssid:andInetAddrData:")]
		IntPtr Constructor(bool isSuc, string bssid, NSData ipAddrData);
	}

	// @protocol ESPTouchDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface ESPTouchDelegate
	{
		// @required -(void)onEsptouchResultAddedWithResult:(ESPTouchResult *)result;
		[Abstract]
		[Export("onEsptouchResultAddedWithResult:")]
		void OnEsptouchResultAddedWithResult(ESPTouchResult result);
	}

	// @interface ESPTouchTask : NSObject
	[BaseType(typeof(NSObject))]
	interface ESPTouchTask
	{
		// @property (assign, atomic) BOOL isCancelled;
		[Export("isCancelled")]
		bool IsCancelled { get; set; }

		// -(id)initWithApSsid:(NSString *)apSsid andApBssid:(NSString *)apBssid andApPwd:(NSString *)apPwd andAES:(id)aes;
		[Export("initWithApSsid:andApBssid:andApPwd:andAES:")]
		IntPtr Constructor(string apSsid, string apBssid, string apPwd, NSObject aes);

		// -(id)initWithApSsid:(NSString *)apSsid andApBssid:(NSString *)apBssid andApPwd:(NSString *)apPwd;
		[Export("initWithApSsid:andApBssid:andApPwd:")]
		IntPtr Constructor(string apSsid, string apBssid, string apPwd);

		// -(id)initWithApSsid:(NSString *)apSsid andApBssid:(NSString *)apBssid andApPwd:(NSString *)apPwd andIsSsidHiden:(BOOL)isSsidHidden __attribute__((deprecated("Use initWithApSsid:(NSString *) andApBssid:(NSString *) andApPwd:(NSString *) instead.")));
		[Export("initWithApSsid:andApBssid:andApPwd:andIsSsidHiden:")]
		IntPtr Constructor(string apSsid, string apBssid, string apPwd, bool isSsidHidden);

		// -(id)initWithApSsid:(NSString *)apSsid andApBssid:(NSString *)apBssid andApPwd:(NSString *)apPwd andTimeoutMillisecond:(int)timeoutMillisecond;
		[Export("initWithApSsid:andApBssid:andApPwd:andTimeoutMillisecond:")]
		IntPtr Constructor(string apSsid, string apBssid, string apPwd, int timeoutMillisecond);

		// -(id)initWithApSsid:(NSString *)apSsid andApBssid:(NSString *)apBssid andApPwd:(NSString *)apPwd andIsSsidHiden:(BOOL)isSsidHidden andTimeoutMillisecond:(int)timeoutMillisecond __attribute__((deprecated("Use initWithApSsid:(NSString *) andApBssid:(NSString *) andApPwd:(NSString *) andTimeoutMillisecond:(int) instead.")));
		[Export("initWithApSsid:andApBssid:andApPwd:andIsSsidHiden:andTimeoutMillisecond:")]
		IntPtr Constructor(string apSsid, string apBssid, string apPwd, bool isSsidHidden, int timeoutMillisecond);

		// -(void)interrupt;
		[Export("interrupt")]
		void Interrupt();

		// -(ESPTouchResult *)executeForResult;
		[Export("executeForResult")]
		//[Verify(MethodToProperty)]
		ESPTouchResult ExecuteForResult { get; }

		// -(NSArray *)executeForResults:(int)expectTaskResultCount;
		[Export("executeForResults:")]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] ExecuteForResults(int expectTaskResultCount);

		// -(void)setEsptouchDelegate:(NSObject<ESPTouchDelegate> *)esptouchDelegate;
		[Export("setEsptouchDelegate:")]
		void SetEsptouchDelegate(ESPTouchDelegate esptouchDelegate);

		// -(void)setPackageBroadcast:(BOOL)broadcast;
		[Export("setPackageBroadcast:")]
		void SetPackageBroadcast(bool broadcast);
	}
}
