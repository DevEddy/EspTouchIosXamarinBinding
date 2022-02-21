# Creating a FAT-Binary
# Doc: https://docs.microsoft.com/de-de/xamarin/ios/platform/binding-objective-c/walkthrough?tabs=macos

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=./EspTouchStatic
PROJECT=$(PROJECT_ROOT)/EspTouchStatic.xcodeproj
TARGET=EspTouchStatic

all: lib$(TARGET).a

lib$(TARGET)-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

lib$(TARGET)-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

lib$(TARGET)-arm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

lib$(TARGET).a: lib$(TARGET)-i386.a lib$(TARGET)-armv7.a lib$(TARGET)-arm64.a
	xcrun -sdk iphoneos lipo -create -output $@ $^

clean:
	-rm -f *.a

# Sharpie Doc: https://docs.microsoft.com/de-de/xamarin/cross-platform/macios/binding/objective-sharpie/get-started#installing
# sharpie xcode -sdks
# sharpie bind --output=EspTouchStatic --namespace=EspTouchStatic --sdk=iphoneos15.2 -scope /Users/eschaefer/Documents/GitHub/EspTouchStaticBinding/EspTouchStatic/EspTouchStatic/ESPTouch/esptouch /Users/eschaefer/Documents/GitHub/EspTouchStaticBinding/EspTouchStatic/EspTouchStatic/ESPTouch/esptouch/*.h
