import 'package:flutter/material.dart';
import 'dart:math';

class Flip extends StatefulWidget {
  final Widget front, back;
  final Function flipCallback;
  Flip({this.front, this.back, this.flipCallback});
  _FlipState createState() => _FlipState();
}

class _FlipState extends State<Flip>{

  bool _displayFront;
  bool _isFlipped = false;

  @override
  void initState(){
    super.initState();
    _displayFront = true;
    _isFlipped = false;
  }
  Widget build(BuildContext context){
    return Container(
      child: _buildFlipAnimation(),
      constraints: BoxConstraints.tight(Size.square(200)),
    );
  }
  void flip(){
    if(!_isFlipped){
      print("is flipped");
      widget.flipCallback();
      this._isFlipped = true;
    }
    setState(() {
      _displayFront = !_displayFront;
    });
  }

  Widget _buildFlipAnimation(){
    return GestureDetector(
      onTap: () => flip(),
      child: AnimatedSwitcher(
        duration: Duration(milliseconds: 200),
        transitionBuilder: __transitionBuilder,
        layoutBuilder: (widget, list) => Stack(children: [widget, ...list]),
        child: _displayFront ? _buildFront() : _buildRear(),
      
      ),
    );
    
    
  } 
  Widget __transitionBuilder(Widget widget, Animation<double> animation) {
    final rotateAnim = Tween(begin: pi, end: 0.0).animate(animation);
    return AnimatedBuilder(
      animation: rotateAnim,
      child: widget,
      builder: (context, widget) {
        final isUnder = (ValueKey(_displayFront) != widget.key);
        var tilt = ((animation.value - 0.5).abs() - 0.5) * 0.003;
        tilt *= isUnder ? -1.0 : 1.0;
        final value = isUnder ? min(rotateAnim.value, pi / 2) : rotateAnim.value;
        return Transform(
          transform: Matrix4.rotationY(value)..setEntry(3, 0, tilt),
          child: widget,
          alignment: Alignment.center,
        );
      },
    );
  }
  Widget __buildLayout({Key key, Widget content, Color backgroundColor}){
    return Container(
      key: key,
      decoration: BoxDecoration(
        shape: BoxShape.rectangle,
        borderRadius: BorderRadius.circular(20.0),
        color: backgroundColor
      ),
      child: Center(
        child: content,
      )
    );
  }

  Widget _buildFront(){
    return __buildLayout(
      key: ValueKey(true),
      backgroundColor: Colors.blue,
      content: this.widget.front
    );
  }
  Widget _buildRear(){
    return __buildLayout(
      key: ValueKey(false),
      backgroundColor: Colors.blue.shade700,
      content: this.widget.back
    );
  }
}

//code from https://medium.com/flutter-community/flutter-flip-card-animation-eb25c403f371