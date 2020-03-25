function addOption(oListbox, text, value, isDefaultSelected, isSelected) {
            var oOption = document.createElement("option");
            oOption.appendChild(document.createTextNode(text));
            oOption.setAttribute("value", value);

            if (isDefaultSelected) oOption.defaultSelected = true;
            else if (isSelected) oOption.selected = true;

            oListbox.appendChild(oOption);
        }


        var size = 5;
        var list1 = document.getElementById("adultsCount");
        var list2 = document.getElementById("childrenCount");;
        for (var i = 1; i <= size; i++) {
            if (i == 1) {
                addOption(list1, i, i, true, true);
            } else {
                addOption(list1, i, i);
            }
        }

        for (var i = 0; i < size; i++) {
            if (i == 0) {
                addOption(list2, i, i, true, true);
            } else {
                addOption(list2, i, i);
            }
        }


        function sync() {
            let list1_value = this.options[this.selectedIndex].value;
            let list2_size = size - list1_value;
            let list2 = document.getElementById("childrenCount");
            list2.options.length = 0;
            for (var i = 0; i <= list2_size; i++) {
                if (i == 0) {
                    addOption(list2, i, i, true, true);
                } else {
                    addOption(list2, i, i);
                }
            }
        }

        var selectToSync = document.getElementById("adultsCount");
        selectToSync.addEventListener('change', sync);
