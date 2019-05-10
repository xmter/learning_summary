// alert($);  检验jQuery环境是否引入

// 闭包
// jQuery 插件的标准写法
;(function (global,factory,plug){
    return factory.call(global,global.jQuery,plug)
})(this,function($,validator){
    // console.log($);
    // $.fn.bootstrapValidator=function(){}
    // 默认值常量对象
    var __DEFS__={
        raise:"change",//最常用的设置为默认值
        errorMsg:"校验失败",
        extendRules:function(rules){
            // console.log('__RULES__');
            $.extend(__RULES__,rules);
        }
    }
    var __RULES__={
        'require':function(){
            // console.log(this.val());
            // console.log('require');
            var val=this.val();      
            return val!=''&&val!=null&&val!=undefined;
        },//必填项
        'email':function(){
            // "^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"
            // console.log('email');
            return /^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$/.test(this.val());
        },//邮箱格式
        'mobile':function(){
            return false;
        },//手机号码格式
        'regex':function(regex){
            console.log(regex);
            return new RegExp(regex).test(this.val());
        },//正则表达式格式
    }
    // 代码全写在闭包中
    $.fn[validator]=function(ops){
        // console.log(this);
        if(!this.is('form')){
            throw new Error("type error[require form tag]");
        }
        var that=this;
        $.extend(this,__DEFS__,ops);//扩展属性和功能
        // dom.getAttribute元素和$dom.attr
        // 健壮性 开闭原则
        this.$fields=this.find('input,textarea,select').not('input[type=submit],input[type=reset],input[type=image],input[type=button]');
        // console.log(this.$fields);
        // console.log(this.raise);
        this.$fields.on(this.raise,function(){
            // console.log(this.value);
            var $field=$(this);//目标对象【jQuery对象】
           
            var $group=$field.parents(".form-group");
            console.log($group);
            $group.removeClass("has-success has-error");
            $group.find(".help-block").remove();

            // console.log($group.find(".glyphicon"));
            $group.find(".glyphicon").removeClass("glyphicon-ok glyphicon-remove");

            var config,error,__err__=true;//校验结果，默认为true
            $.each(__RULES__,function(rule,valid){
                // console.log(rule,valid);
                config=$field.data('bv-'+rule);
                if(config){
                    // console.log(rule);
                    // 校验，调用
                    __err__=valid.call($field,config);
                    $group.addClass(__err__?"has-success":"has-error");
                    $group.find(".glyphicon").addClass("glyphicon-ok");
                   
                    if(!__err__){
                        error=$field.data('bv-'+rule+'-error')||that.errorMsg;
                        // console.log("<span class='help-block'>"+error+"</span>");
                        $field.after("<span class='help-block'>"+error+"</span>");

                        $group.find(".glyphicon").addClass("glyphicon-remove");
                    }
                    return __err__;
                }else{

                }
            });
            console.log(__err__+"aaa");
        });
        return this;
    }
},'bootstrapValidator');
