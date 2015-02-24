-- Wrapper for Yutils-ASS => NyuFX-ASS
-- Add missing informations to Nyu parser result table which are missing in Yutils

wrapper = {
	
	fix_line = function(line)
		line.infade = line.leadin
		line.outfade = line.leadout
		line.k_text = line.text
		line.text = line.text_stripped
		line.intlead = line.internal_leading
		line.extlead = line.external_leading
		
		line.x = tonumber(line.x)
		line.right = tonumber(line.right)
		line.left = tonumber(line.left)
		line.center = tonumber(line.center)
		line.width = tonumber(line.width)
	end,
	
	fix_syl = function(syl)
		syl.intlead = syl.internal_leading
		syl.extlead = syl.external_leading
		
		syl.x = tonumber(syl.x)
		syl.right = tonumber(syl.right)
		syl.left = tonumber(syl.left)
		syl.center = tonumber(syl.center)
		syl.width = tonumber(syl.width)
	end,
	
	fix_word = function(word)
		word.intlead = word.internal_leading
		word.extlead = word.external_leading
		
		word.x = tonumber(word.x)
		word.right = tonumber(word.right)
		word.left = tonumber(word.left)
		word.center = tonumber(word.center)
		word.width = tonumber(word.width)
	end,
	
	fix_char = function(char_)
		char_.intlead = char_.internal_leading
		char_.extlead = char_.external_leading
		
		char_.x = tonumber(char_.x)
		char_.right = tonumber(char_.right)
		char_.left = tonumber(char_.left)
		char_.center = tonumber(char_.center)
		char_.width = tonumber(char_.width)
	end,
	
	trim = function(text)
		local prespace, subtext, postspace = text:match("([ \t]*)([^ \t]*)([ \t]*)")
		return subtext, prespace:len(), postspace:len()
	end,
	
	reparse = function()
		for li, line in ipairs(lines) do
			wrapper.fix_line(line)
			
			for si, syl in ipairs(line.syls) do
				wrapper.fix_syl(syl)
			end
			
			for wi, word in ipairs(line.words) do
				wrapper.fix_word(word)
			end
			
			for ci, char_ in ipairs(line.chars) do
				wrapper.fix_char(char_)
			end
			
			local c_word, c_syl = 1, 1
			for pre_tag, tag_time, post_tag, text in line.k_text:gmatch("{(.-)\\[kK][of]?(%d+)(.-)}([^{]*)") do
				local _text, _prespace, _postspace = wrapper.trim(text)
				local inline_fx = string.match(pre_tag .. post_tag, "\\%-([^\\]*)") or ""
				if _prespace > 0 then c_word = c_word + 1 end
				line.syls[c_syl].word_i = c_word
				if _postspace > 0 then c_word = c_word + 1 end
				c_syl = c_syl + 1
			end
		end
	end
	
}